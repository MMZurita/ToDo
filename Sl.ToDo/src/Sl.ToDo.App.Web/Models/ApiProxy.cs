using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Sl.ToDo.App.Web.Models
{
	public class ApiProxy : IDisposable
	{
		private readonly string _baseUrl;
		private Lazy<HttpClient> _lazyClient;

		protected ApiProxy(string baseUrl)
		{
			_baseUrl = baseUrl.Trim('/');
			_lazyClient = new Lazy<HttpClient>(() => new HttpClient());
		}

		protected HttpClient Client()
		{
			if (_lazyClient == null)
			{
				throw new ObjectDisposedException("WebClient has been disposed");
			}

			return _lazyClient.Value;
		}

		protected async Task<T> Execute<T>(string urlSegment)
		{
			var result = await Client().GetAsync(_baseUrl + '/' + urlSegment.TrimStart('/'));
			return await result.Content.ReadAsAsync<T>();
		}

		protected async Task<T> ExecutePost<T>(T content)
		{
			var result = await Client().PostAsJsonAsync(_baseUrl, content);
			return await result.Content.ReadAsAsync<T>();
		}

		~ApiProxy()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(false);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_lazyClient == null) return;
			if (!disposing) return;
			if (!_lazyClient.IsValueCreated) return;

			_lazyClient.Value.Dispose();
			_lazyClient = null;
		}
	}
}