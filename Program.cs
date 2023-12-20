using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductApi.Data;
using ProductApi.Models;
using ProductApi.Servises;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtOptions = builder.Configuration
    .GetSection("JwtOptions")
    .Get<JwtOptions>();

builder.Services.AddSingleton(jwtOptions);
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(opts =>
//    {
//        //convert the string signing key to byte array
//        byte[] signingKeyBytes = Encoding.UTF8
//            .GetBytes(jwtOptions.SigningKey);

//        opts.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = jwtOptions.Issuer,
//            ValidAudience = jwtOptions.Audience,
//            IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
//        };
//    });

//).AddJwtBearer();
// Add services to the container.

var conn = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString: conn));
builder.Services.AddScoped<ICustomer,CustomerServise>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHangfire(con => con.UseSqlServerStorage( builder.Configuration.GetConnectionString("default")));
//builder.Services.AddSingleton<IConfiguration>(Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHangfireServer();
app.UseHangfireDashboard();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
        c.InjectStylesheet("/StyleSheet1.css");
    }); 
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

RecurringJob.AddOrUpdate(
    "myrecurringjob",
    () => Console.WriteLine("Recurring!"),
    Cron.Minutely);

app.Run();
