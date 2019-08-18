using System.Net.Http;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public interface IHttpClient
    {
        Task<string> GetStringAsync(string uri, string autorizationToken = null,
            string authorizationMethod = "Bearer");

        Task<HttpResponseMessage> PostAsync<T>(string uri, T item, string autorizationToken = null,
            string authorizationMethod = "Bearer");

        Task<HttpResponseMessage> PutAsync<T>(string uri, T item, string autorizationToken = null,
            string authorizationMethod = "Bearer");

        Task<HttpResponseMessage> DeleteAsync(string uri, string autorizationToken = null,
           string authorizationMethod = "Bearer");
    }
}
