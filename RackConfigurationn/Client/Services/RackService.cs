using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using RackConfigurationn.Shared.Models;
using System;

namespace RackConfigurationn.Client.Services
{
    public class RackService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public RackService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Dapper ve EntityFramework JSON uyumu için
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<double>?> GetAllDepthsAsync()
        {
            string url = "api/Data/depth-options-dapper";
            try
            {
                return await _httpClient.GetFromJsonAsync<List<double>>(url);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Derinlik API Hatası: {ex.Message}");
                return null;
            }
        }

        public async Task<List<DeckOption>?> GetCompatibleDeckOptionsAsync(double depth)
        {
            string url = $"api/Data/deck-options?depth={depth}";
            try
            {
                return await _httpClient.GetFromJsonAsync<List<DeckOption>>(url, _jsonOptions);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Deck API Hatası: {ex.Message}");
                return null;
            }
        }

        
        public async Task<double> CalculatePriceAsync(Rack rackDraft)
        {
            try
            {
                
                var response = await _httpClient.PostAsJsonAsync("api/Pricing/calculate", rackDraft);

                if (response.IsSuccessStatusCode)
                {
                    
                    var result = await response.Content.ReadFromJsonAsync<PriceResult>(_jsonOptions);
                    return result?.TotalPrice ?? 0;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"Fiyat Hatası: {error}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Fiyat Hesaplama Hatası: {ex.Message}");
            }
            return 0;
        }

      
        public async Task<bool> CreateRackAsync(Rack rack)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Rack", rack);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Kayıt Hatası: {ex.Message}");
                return false;
            }
        }
    }

    
    public class PriceResult
    {
        public double TotalPrice { get; set; }
    }
}
