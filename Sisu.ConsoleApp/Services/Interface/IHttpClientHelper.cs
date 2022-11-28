using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisu.ConsoleApp.Services.Interface
{
    public interface IHttpClientHelper<T>
    {
        Task<T> GetSingleItemRequest(string apiUrl, CancellationToken token = default);
        Task<T[]> GetMultipleItemsRequest(string apiUrl, CancellationToken token = default);
        Task<T> PostRequest(string apiUrl, T postObject, CancellationToken token = default);
        Task PutRequest(string apiUrl, T putObject, CancellationToken token = default);
        Task DeleteRequest(string apiUrl, CancellationToken token = default);
    }
}
