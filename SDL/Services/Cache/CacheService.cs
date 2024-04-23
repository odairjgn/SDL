using LiteDB;
using SDL.Models.Cache;
using SDL.Services.Log;

namespace SDL.Services.Cache
{
    public class CacheService : IDisposable
    {
        private const int MaxCacheItens = 1000;
        private static CacheService? instance;
        private readonly TimeSpan _expireTimeSpan = TimeSpan.FromHours(24);
        private readonly LiteDatabase _db;

        public static CacheService Instance => instance ??= new CacheService();

        private CacheService()
        {
            var dbFile = Path.Combine(Directory.GetCurrentDirectory(), "cache.db");

            try
            {
                _db = new LiteDatabase(dbFile);
                EnsureIndex();
            }
            catch (Exception ex)
            {
                // Maybe corruppted
                if (File.Exists(dbFile))
                {
                    File.Delete(dbFile);
                    _db = new LiteDatabase(dbFile);
                    EnsureIndex();
                }

                LogService.Instance.WriteException(ex);
            }
        }

        public byte[]? this[string key]
        {
            get
            {
                var collection = _db.GetCollection<CachedItem>();
                var item = collection.FindById(key);

                if (item == null)
                {
                    return null;
                }
                else if (item.ExpireDate < DateTime.Now)
                {
                    collection.Delete(item.Id);
                    _db.Commit();
                    return null;
                }

                return item.Data;
            }
            set
            {
                var collection = _db.GetCollection<CachedItem>();
                var item = collection.FindById(key);

                if (item != null)
                {
                    item.Data = value;
                    collection.Update(item);
                }
                else
                {
                    item = new CachedItem
                    {
                        Id = key,
                        Data = value,
                        ExpireDate = DateTime.Now + _expireTimeSpan
                    };

                    collection.Insert(item);
                }

                _db.Commit();
                CacheMaintenance();
            }
        }

        public void Dispose() => _db.Dispose();

        private void CacheMaintenance()
        {
            var collection = _db.GetCollection<CachedItem>();
            var count = collection.Count() - MaxCacheItens;

            if (count > 0)
            {
                var toDelete = collection
                    .Query()
                    .OrderBy(x => x.ExpireDate)
                    .Select(x => x.Id)
                    .Limit(count)
                    .ToList();

                toDelete.ForEach(x => collection.Delete(x));
                _db.Commit();
            }
        }

        private void EnsureIndex()
        {
            var collection = _db.GetCollection<CachedItem>();
            collection.EnsureIndex(x => x.ExpireDate);
            _db.Commit();
        }
    }
}
