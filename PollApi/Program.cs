
using Dal;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PollApi.Filters;
using PollApi.Hubs;
using Service;
using System.Text;

namespace PollApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(cfg =>
            {
                cfg.Filters.Add(typeof(ExceptionFilter));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IAuthPollRepository, AuthPollRepository>();
            builder.Services.AddScoped<IPollRepository, PollRepository>();
            builder.Services.AddScoped<IPollEventService, PollEventService>();
            builder.Services.AddScoped<IPollVoteRepository, PollVoteRepository>();
            builder.Services.AddScoped<IPollVoteService, PollVoteService>();
            builder.Services.AddScoped<EmailService, EmailService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials()
                           .WithOrigins("http://localhost:4200", "http://localhost:3000", "https://localhost:5173");
                });
            });
            builder.Services.Configure<ApiBehaviorOptions>(options =>
                options.InvalidModelStateResponseFactory = actionContext =>
                {

                    return new BadRequestObjectResult(actionContext.ModelState);
                }
            );
            builder.Services.AddDbContext<PollDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:PollDb"], b => b.MigrationsAssembly("PollApi"));
            });
            builder.Services.AddAuthentication().AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["at"];
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        context.Response.Redirect("account/login");
                        return Task.CompletedTask;
                    }
                    
                };
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
            builder.Services.AddSignalR();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<PollHub>("/poll-event");
            });
            app.Run();
        }
    }
}