using MainApi.HttpClients;
using MainApi.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<TokenMessageHandler>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.RegisterHttpClients(builder.Configuration);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddAuthentication(p =>
    {
        p.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        p.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddOpenIdConnect(
    options =>
    {
        options.Authority = "http://host.docker.internal:8080/realms/MyRealm";
        options.ClientId = "ExampleApplication";
        options.ClientSecret = "oY8kfCwoJuqB5oWqrJjwc7SN66XnjEN6";
        options.RequireHttpsMetadata = false;
        options.ResponseType = "code";
        options.UsePkce = true;
        options.SaveTokens = true;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidAudience = "ExampleApplication"
        };
        options.Events = new OpenIdConnectEvents
        {
            OnTokenValidated = context =>
            {
                return Task.CompletedTask;
            }
        };
    }
    );
builder.Services.AddAuthorization(p =>
{
    p.AddPolicy("MustBeAuthenticated", policy => policy.AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme).RequireAuthenticatedUser());
    p.DefaultPolicy = p.GetPolicy("MustBeAuthenticated") ?? throw new InvalidOperationException("Attempted to use an undefined policy as Default");
    p.FallbackPolicy = p.DefaultPolicy;
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers().RequireAuthorization();

app.MapSwagger().RequireAuthorization();

app.Run();
