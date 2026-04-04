// using StudentPortal;
// using Microsoft.EntityFrameworkCore;
// using StudentPortal.Data;
// using StudentPortal.Components;
// using StudentPortal.Components.Shared.Services;

// var builder = WebApplication.CreateBuilder(args);
// builder.WebHost.UseUrls("http://0.0.0.0:8080");

// builder.Services.AddRazorPages();
// builder.Services.AddServerSideBlazor();
// builder.Services.AddHttpClient();
// builder.Services.AddRazorComponents()
//      .AddInteractiveServerComponents();


// builder.Services.AddSingleton<StudentAccount>();
// builder.Services.AddScoped<DegreeProgress>();
// builder.Services.AddSingleton<StudentAccount>();
// builder.Services.AddScoped<StudentSchedule>();

// builder.Services.AddDbContext<AppDbContext>(options =>
//      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//     db.Database.EnsureCreated();
// }

// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error");
// }

// app.UseStaticFiles();
// app.UseRouting();

// app.MapRazorPages();
// app.MapBlazorHub();
// //app.MapFallbackToPage("/_Host");
// //app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

// // Initialize the database
// //var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
// // using (var scope = scopeFactory.CreateScope())
// // {
// //     var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
// //     if (db.Database.EnsureCreated())
// //     {
// //         SeedData.Initialize(db);
// //     }
// // }
// app.MapRazorComponents<App>()
//     .AddInteractiveServerRenderMode();
// app.MapStaticAssets();

// app.Run();








// using Microsoft.EntityFrameworkCore;
// using StudentPortal.Data;
// using StudentPortal.Components;
// using StudentPortal.Components.Shared.Services;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddRazorComponents()
//     .AddInteractiveServerComponents();
// builder.WebHost.UseUrls("http://0.0.0.0:8080");

// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddServerSideBlazor();

// builder.Services.AddSingleton<StudentAccount>();
// builder.Services.AddScoped<DegreeProgress>();
// builder.Services.AddSingleton<StudentAccount>();
// builder.Services.AddScoped<StudentSchedule>();


// var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//     db.Database.EnsureCreated();
// }

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Error", createScopeForErrors: true);
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }
// else
// {
//     // Disable caching for static files in development
//     app.Use(async (context, next) =>
//     {
//         context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
//         context.Response.Headers["Pragma"] = "no-cache";
//         context.Response.Headers["Expires"] = "0";
//         await next();
//     });
// }

// //app.UseHttpsRedirection();


// app.UseAntiforgery();

// app.MapBlazorHub(); 
// app.MapStaticAssets();
// app.MapRazorComponents<App>()
//     .AddInteractiveServerRenderMode();

// app.Run();



using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Components;
using StudentPortal.Components.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ❌ REMOVE THIS (conflicts with new model)
// builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<StudentAccount>();
builder.Services.AddScoped<DegreeProgress>();
builder.Services.AddScoped<StudentSchedule>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
else
{
    app.Use(async (context, next) =>
    {
        context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
        context.Response.Headers["Pragma"] = "no-cache";
        context.Response.Headers["Expires"] = "0";
        await next();
    });
}

// app.UseHttpsRedirection();

app.UseAntiforgery();

// ❌ REMOVE THIS (old hosting model)
// app.MapBlazorHub(); 

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();