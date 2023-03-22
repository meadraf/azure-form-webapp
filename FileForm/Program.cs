using Azure.Storage.Blobs;
using FileForm.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton(x =>
    new BlobServiceClient(builder.Configuration.GetValue<string>("BlobStorageConnectionString")));
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IBlobService, BlobService>();
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();