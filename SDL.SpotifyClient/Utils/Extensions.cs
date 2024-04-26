namespace SDL.SpotifyClient.Utils
{
    public static class Extensions
    {
        public static TOut Pipe<TIn, TOut>(this TIn input, Func<TIn, TOut> transform)
        {
            return transform(input);
        }
    }
}
