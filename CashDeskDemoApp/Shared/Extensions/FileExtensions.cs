using System.IO;

namespace CashDeskDemoApp.Shared.Extensions
{
    /// <summary>
    /// File Extension Methods
    /// </summary>
    public static class FileExtensions
    {
        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
