using System.Data;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RackConfigurationn.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddRazorPages();

// Swagger Servisleriii
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB Context (EF Core) ve Dapper Baðlantýsý
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(
    builder.Configuration.GetConnectionString("sqlConnection")
));

// Önemli: CORS ayarý, API çaðrýlarý için gereklidir (Blazor WASM ayný origin'den gelse bile ileride gerekebilir)
builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
// ----------------------

var app = builder.Build();

// --- PIPELINE BÖLÜMÜ ---
if (app.Environment.IsDevelopment())
{
    //app.UseWebAssemblyDebugging();

    // SWAGGER'I KULLAN
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rack Config API v1");
    });
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

// CORS'u yönlendirmeden sonra etkinleþtir
app.UseCors("CorsPolicy");

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();