namespace SDL.Services.Utils
{
    public static class FileNaming
    {
        const string ToRemove = "\">|<?*:/";

        public static string ToSafeFilePath(string path)
        {
            foreach (var c in ToRemove)
            {
                path = path.Replace(c, '_');
            }

            return path;
        }
    }
}
