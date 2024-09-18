using Company.Data.Context;
using Company.Data.Entity;
using Company.Repository.Interfaces;
using Company.Repository.Repositories;
using Company.Service.Interface.DepartmenInterface;
using Company.Service.Interface.EmployeeInterface;
using Company.Service.Mapping;
using Company.Service.Service.Departmentservice;
using Company.Service.Service.Employeeservice;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



public class Program
{
    public static void Main(string[] args)
  {
        var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<CompanyDbContext>(o =>
        {

            o.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnectionString"));

        });

        //builder.Services.AddScoped< IDepartmentRepository , DepartmentRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();

        builder.Services.AddScoped<IDepartmentService, DepartmentService>();
        // builder.Services.AddAutoMapper(x => x.AddProfile(new EmployeeProfile()));
        builder.Services.AddAutoMapper(x => x.AddProfile(new EmployeeProfile()));
        builder.Services.AddAutoMapper(x => x.AddProfile(new DepartmentProfile()));


        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
        {
            config.Password.RequiredUniqueChars = 2;
            config.Password.RequireDigit = true;
            config.Password.RequireLowercase = true;
            config.Password.RequireUppercase = true;
            config.Password.RequireNonAlphanumeric = true;
            config.Password.RequiredLength = 6;
            config.User.RequireUniqueEmail = true;
            config.Lockout.AllowedForNewUsers = true;
            config.Lockout.AllowedForNewUsers = true;
            config.Lockout.MaxFailedAccessAttempts = 3;
            config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);







        }).AddEntityFrameworkStores<CompanyDbContext>().AddDefaultTokenProviders();






        builder.Services.ConfigureApplicationCookie(option =>
        {
            option.Cookie.HttpOnly = true;
            option.ExpireTimeSpan = TimeSpan.FromDays(1);
            option.SlidingExpiration = true;
            option.LoginPath = "/Account/Login";
            option.LogoutPath = "/Account/Logout";
            option.AccessDeniedPath = "/Account/AccessDenied";
            option.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            option.Cookie.SameSite=SameSiteMode.Strict;





















        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }


        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Account}/{action=SignUp}");

        app.Run();
    }
}