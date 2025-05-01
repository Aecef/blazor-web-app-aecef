namespace Pareidolia.Models
{
    public class WeightModel
    {
        public WeightModel(string collectionId, string collectionName, DateTime created, string id, DateTime updated, string user, float weight ,string etc = "")
        {
            this.collectionId = collectionId;
            this.collectionName = collectionName;
            this.created = created;
            this.etc = etc;
            this.id = id;
            this.updated = updated;
            this.user = user;
            this.weight = weight;
        }
        public WeightModel()
        {
            this.collectionId = "";
            this.collectionName = "";
            this.created = DateTime.Now;
            this.etc = "";
            this.id = "";
            this.updated = DateTime.Now;
            this.user = "";
            this.weight = 0;
        }
        public string collectionId { get; set; }
        public string collectionName { get; set; }
        public DateTime created { get; set; }
        public string? etc { get; set; }
        public string id { get; set; }
        public DateTime updated { get; set; }
        public string user { get; set; }
        public float weight { get; set; }
    }
}
