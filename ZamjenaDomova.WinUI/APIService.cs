using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using ZamjenaDomova.Model;

namespace ZamjenaDomova.WinUI
{
    public class APIService
    {
        public static string Token { get; set; }

        private readonly string _route = null;
        public APIService(string route)
        {
            _route = route;
        }
        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
        } 
        public async Task<List<T>> GetListingsCount<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/Count";
            return await url.WithOAuthBearerToken(Token).GetJsonAsync<List<T>>();
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            return await url.WithOAuthBearerToken(Token).PostJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithOAuthBearerToken(Token).PutJsonAsync(request).ReceiveJson<T>();
        } 
        public async Task<T> Delete<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithOAuthBearerToken(Token).DeleteAsync().ReceiveJson<T>();
        }
    }
}
