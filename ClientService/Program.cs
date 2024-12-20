using Authentication.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddStandardAuthentication(builder.Configuration);

builder.Services.AddAuthorization(p =>
{
    p.FallbackPolicy = p.DefaultPolicy;
    p.AddPolicy("CanGetClientInfo", builder => builder.RequireRole("ClientReader"));
    p.AddPolicy("CanReadClientSettings", builder => builder.RequireRole("ClientManager"));
});
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
else
{
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
