using System;
using System.Threading.Tasks;
using BoutinFlegel.Authentication.Proto;
using Grpc.Net.Client;

namespace Narrator.Services
{
	public class ClockService
	{
		private GrpcChannel Channel { get; }
		private Clock.ClockClient ClockClient { get; }

		public ClockService()
		{
			Channel = GrpcChannel.ForAddress("https://localhost:5001");
			ClockClient = new Clock.ClockClient(Channel);
		}

		public DateTime GetTime()
		{
			var reply = ClockClient.GetTime(new Empty { });
			var time = DateTime.FromFileTimeUtc(reply.Time.ToDateTimeOffset()
				.ToUnixTimeMilliseconds());

			return time;
		}
	}
}
