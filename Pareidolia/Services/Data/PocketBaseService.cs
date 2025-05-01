using PocketBaseCore;
using System.Text.Json.Nodes;
using Pareidolia.Models;

namespace Pareidolia.Services.Data
{
    public class PocketBaseService
    {
        private readonly PocketBaseClient _pocketBaseClient;
        private readonly string _baseUrl;
        private readonly string _password = "";
        private readonly string _identity = "";
        public PocketBaseService()
        {
            _baseUrl = "https://pocketbase-chh.fly.dev/_/";
            _pocketBaseClient = new PocketBaseClient(_baseUrl);
        }

        public async Task AuthenticateConnection()
        {
            try { await _pocketBaseClient.AuthenticateAsync(_identity, _password); }
            catch (Exception ex) { 
                throw new Exception($"Error authenticating to PocketBase: {ex.Message}");
            }
        }
        public async Task<List<WeightModel>> GetDataAsync()
        {
            var weights = await _pocketBaseClient.GetRecordsAsync<JsonNode>("weights");
            if (weights == null || weights.Items == null)
            {
                throw new Exception("No data found in PocketBase.");
            }
            // Parse the date into WeightModel objects
            var weightModels = new List<WeightModel>();
            foreach (var item in weights.Items)
            {
                var weightModel = new WeightModel(
                    collectionId: item["collectionId"]?.ToString() ?? "",
                    collectionName: item["collectionName"]?.ToString() ?? "",
                    created: DateTime.Parse(item["created"]?.ToString() ?? DateTime.Now.ToString()),
                    id: item["id"]?.ToString() ?? "",
                    updated: DateTime.Parse(item["updated"]?.ToString() ?? DateTime.Now.ToString()),
                    user: item["user"]?.ToString() ?? "",
                    weight: float.Parse(item["weight"]?.ToString() ?? "0"),
                    etc: item["etc"]?.ToString() ?? ""
                );
                weightModels.Add(weightModel);
            }
            return weightModels;

        }
    }
}
