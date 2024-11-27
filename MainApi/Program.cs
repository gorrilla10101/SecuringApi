using Authentication.Extensions;
using MainApi.HttpClients;
using MainApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<TokenMessageHandler>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.RegisterHttpClients(builder.Configuration);
// Add services to the container.
builder.Services.AddStandardAuthentication(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
