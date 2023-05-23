using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using porthealthvis.DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();



builder.Services.AddDbContext<DbnewContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnection")));


builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();


app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

app.UseSession();

app.MapControllers();

app.UseEndpoints(endpoints =>
{  
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action}/{id?}",
        defaults: new { controller = "Home", action = "Index" });

    endpoints.MapFallbackToFile("index.html");
});


app.Run();
