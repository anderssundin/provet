var builder = WebApplication.CreateBuilder(args);
 builder.Services.AddControllersWithViews();        // Aktivera MVC
var app = builder.Build();

app.UseStaticFiles();       // Aktivera möjlighet att använda statiska filer
app.UseRouting();            // Aktiverar routing

app.MapControllerRoute(                         // Bestämmer hur sökvägar skall se ut
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();
