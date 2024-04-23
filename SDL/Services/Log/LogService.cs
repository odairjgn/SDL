using static System.Console;

namespace SDL.Services.Log
{
    public class LogService
    {
        private static LogService? instance;
        public static LogService Instance => instance ??= new LogService();

        private LogService() { }

        public void WriteException(Exception ex)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine(ex.ToString());
            ResetColor();
        }
    }
}
