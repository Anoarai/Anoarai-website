using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using System.Text;
using System;
using Website.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

Configure(app, app.Environment);

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    services.AddScoped<IDatabaseContext, AppDbContext>();
    var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
    var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=PersonalWebsite;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    services.AddDbContext<AppDbContext>(b => b.UseSqlServer(connectionString));
    //services.AddScoped<ITokenService, TokenService>();
    //services.AddScoped<IUserService, UserService>();
    //services.AddScoped<ISongService, SongService>();
    //services.AddScoped<ISearchService, SearchService>();
    //services.AddScoped<IPlaylistService, PlaylistService>();
    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



    services.AddServerSideBlazor();
    services.AddControllersWithViews()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
        });

    services.AddEndpointsApiExplorer();

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            //.GetBytes(Environment.GetEnvironmentVariable("Sharmya_token"))),
            .GetBytes("testToken")),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

}
void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapBlazorHub();
    });
}
