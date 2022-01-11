using System.IO.Compression;
using FlexNews.Api.Base;
using FlexNews.Api.Config;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;
IWebHostEnvironment env = builder.Environment;

// Add services to the container.
builder.Services.ConfigureMongoDb(config);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().ConfigureApiBehaviours();
builder.Services.RegisterApiVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterSwaggerGen("Flex News", "Documentação de auxílio para integração");
builder.Services.AddCors();
builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
builder.Services.AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>());
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.RegisterApiVersioning();
builder.Services.ConfigureServices();

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.RegisterSwaggerUI(
        "FlexNews API Documentation",
        app.Services.GetRequiredService<IApiVersionDescriptionProvider>()
    );
}
app.UseCors(options => {
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});
app.UseHttpsRedirection();
app.UseResponseCompression();
app.UseRouting();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.MapControllers();
app.Run();
