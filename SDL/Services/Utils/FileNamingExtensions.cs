namespace SDL.Services.Utils
{
    public static class FileNamingExtensions
    {
        const string ToRemove = "\">|<?*:/";

        public static string ToSafeFilePath(this string path)
        {
            return new string(path.Select(x => ToRemove.Contains(x) ? '_' : x).ToArray());
        }
    }
}
