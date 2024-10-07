using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Serve static files from the "template/vendor" folder
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "template", "vendor")),
    RequestPath = "/vendor" // Prefix for accessing vendor libraries
});

// Serve static files from the "template/assets" folder
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "template", "assets")),
    RequestPath = "/assets" // Prefix for accessing assets
});

// Serve the index.html file from the "template" folder
app.MapGet("/", async context =>
{
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "template", "index.html");
    await context.Response.SendFileAsync(filePath);
});

// Ensure that the app runs
app.Run();