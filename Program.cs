var builder = WebApplication.CreateBuilder(args);
 builder.Services.AddControllersWithViews();        // Aktivera MVC
 
 builder.Services.AddDistributedMemoryCache();      // Aktiverar sessions

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(120);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseStaticFiles();       // Aktivera möjlighet att använda statiska filer
app.UseRouting();            // Aktiverar routing

app.MapControllerRoute(                         // Bestämmer hur sökvägar skall se ut
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.UseSession(); // Aktiverar sessions

app.Run();
