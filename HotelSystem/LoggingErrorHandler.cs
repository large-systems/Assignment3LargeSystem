
using Microsoft.ApplicationInsights;
using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace HotelSystem
{
    class LoggingErrorHandler : IErrorHandler
    {
        private readonly TelemetryClient client = new TelemetryClient();

        public bool HandleError(System.Exception error)
        {
            client.TrackException(error);
            return false;
        }

        public void ProvideFault(System.Exception error, MessageVersion version, ref Message fault)
        {
        }
    }
}