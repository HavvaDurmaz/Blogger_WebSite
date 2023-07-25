using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();

builder.Services.AddAuthentication(x => {
    x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options => {
    options.LoginPath = "/admin/Login";
    options.LogoutPath = "/admin/Logout";
    options.AccessDeniedPath = "/admin/Login";
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(x => x.MapDefaultControllerRoute());

// ADMIN PANELININ ÇALIÞABÝLMESÝ GEREKLÝ OLAN ROUTING AYARAMASI
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=login}/{action=Index}/{id?}"
    );
});

app.Run();