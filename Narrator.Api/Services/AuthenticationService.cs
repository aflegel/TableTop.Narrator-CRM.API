using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Options;

namespace Narrator.Services
{
	public class AuthenticationOptions
	{
		public string AuthenticationUrl { get; set; }
	}

	public class AuthenticationService
	{
		private GrpcChannel Channel { get; }
		private AuthenticationOptions Options { get; }
		private string Token { get; set; }

		public AuthenticationService(IOptions<AuthenticationOptions> options)
		{
			Options = options.Value;

			var credentials = CallCredentials.FromInterceptor((context, metadata) =>
			{
				if (!string.IsNullOrEmpty(Token))
				{
					metadata.Add("Authorization", $"Bearer {Token}");
				}
				return Task.CompletedTask;
			});

			// SslCredentials is used here because this channel is using TLS.
			// Channels that aren't using TLS should use ChannelCredentials.Insecure instead.
			Channel = GrpcChannel.ForAddress($"https://{Options.AuthenticationUrl}", new GrpcChannelOptions
			{
				Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
			});
		}

		private async Task<string> Authenticate()
		{
			Console.WriteLine($"Authenticating as {Environment.UserName}...");
			var httpClient = new HttpClient();
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri($"https://{Options.AuthenticationUrl}/generateJwtToken?name={HttpUtility.UrlEncode(Environment.UserName)}"),
				Method = HttpMethod.Get,
				Version = new Version(2, 0)
			};
			var tokenResponse = await httpClient.SendAsync(request);
			tokenResponse.EnsureSuccessStatusCode();

			var token = await tokenResponse.Content.ReadAsStringAsync();
			Console.WriteLine("Successfully authenticated.");

			return token;
		}
	}
}
