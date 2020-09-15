using Newtonsoft.Json;

namespace CashDeskDemoApp.Shared.Extensions
{
    /// <summary>
    /// Generic Extension Methods
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Gets the model from json string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString">The json string.</param>
        /// <returns></returns>
        public static T GetModelFromJsonString<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
