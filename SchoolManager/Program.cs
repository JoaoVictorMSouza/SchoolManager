using SchoolManager.Application;
using SchoolManager.Application.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

//Registrando os servi�os
services.ApiRegister();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();