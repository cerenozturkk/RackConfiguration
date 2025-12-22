using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RackConfigurationn.Client;
using System.Text.Json;
using System.Net.Http;
using System;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// --- KRÝTÝK DÜZELTME: HttpClient Kaydý ---

// Blazor WASM'da BaseAddress'i ayarlý olan HttpClient'ý DI'a kaydetmenin standart yolu.
// Bu, RackService constructor'ýna otomatik olarak enjekte edilir.
// API'nizin çalýþtýðý kesin adresi kullanýyoruz (7237 portu).
// Bu, Client'ýn tüm API isteklerini doðru Server'a yönlendirmesini saðlar.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7237/") });

// RackService'i DI'a kaydeder.
builder.Services.AddScoped<RackConfigurationn.Client.Services.RackService>();

// --- KRÝTÝK JSON AYARI ---

// Dapper'dan gelen veriyi (küçük harfli alanlar) C# modeline eþleþtirmek için JSON ayarý.
builder.Services.Configure<JsonSerializerOptions>(options =>
{
    options.PropertyNameCaseInsensitive = true;
});

await builder.Build().RunAsync();
