using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Components;
using StudentPortal.Components.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<StudentAccount>();
builder.Services.AddScoped<DegreeProgress>();
builder.Services.AddSingleton<StudentAccount>();
builder.Services.AddScoped<StudentSchedule>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // Disable caching for static files in development
    app.Use(async (context, next) =>
    {
        context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
        context.Response.Headers["Pragma"] = "no-cache";
        context.Response.Headers["Expires"] = "0";
        await next();
    });
}

//app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapBlazorHub(); 
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
