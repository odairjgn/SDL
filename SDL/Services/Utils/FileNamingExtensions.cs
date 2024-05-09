namespace SDL.Services.Utils
{
    public static class FileNamingExtensions
    {
        const string ToRemove = "\">|<?*:/";

        public static string ToSafeFilePath(this string path)
        {
            foreach (var c in ToRemove)
            {
                path = path.Replace(c, '_');
            }

            return path;
        }
    }
}
