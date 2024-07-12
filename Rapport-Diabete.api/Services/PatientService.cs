using Azure;
using Rapport_Diabete.api.Models;
using Serilog;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Rapport_Diabete.api.Services
{
    public class PatientService
    {
        private readonly HttpClient httpClient;
        public PatientService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://ocelot:5050/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            this.httpClient = httpClient;
            
        }

        public async Task<PatientModel?> Get(int id, string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("Bearer ", ""));

            try
            {
                // Effectuer la requête GET
                HttpResponseMessage response = await httpClient.GetAsync($"gateway/patient/get?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<PatientModel?>();
                }
                else
                {
                    // Log l'erreur pour plus de détails
                    Log.Error($"Request failed with status code: {response.StatusCode} and reason: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Log l'exception
                Log.Error($"HTTP request failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log toute autre exception
                Log.Error($"Unexpected error: {ex.Message}");
            }
            return null;
        }
    }
}
