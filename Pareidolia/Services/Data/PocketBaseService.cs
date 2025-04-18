using PocketBaseCore;
using System.Text.Json;
using System.Text.Json.Nodes;

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
        public async Task<List<JsonNode>> GetDataAsync()
        {
            var weights = await _pocketBaseClient.GetRecordsAsync<JsonNode>("weights");
            return weights.Items;

        }
    }
}
