using LiteDB;

namespace SDL.Models.Cache
{
    public class CachedItem
    {
        [BsonId]
        public string Id { get; set; }

        public byte[]? Data { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
