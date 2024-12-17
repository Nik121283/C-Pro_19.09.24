
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();

    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
            @"E:\Обучение\C#\C# Hillel Pro 09.09.24\Site\Vizitka"),
        RequestPath = "/site"
    });

    app.MapGet("/", context =>
    {
        context.Response.Redirect("/site/htmlpage.html");
        return Task.CompletedTask;
    });

    app.Run();
