﻿using System.ServiceModel;

namespace CefSharp.Internals
{
    public class SubProcessProxySupport
    {
        private const string BaseAddress = "net.pipe://localhost";
        private const string ServiceName = "CefSharpSubProcessProxy";

        public static string GetServiceName(int parentProcessId, int browserId)
        {
            return string.Join("/", BaseAddress, ServiceName, parentProcessId, browserId);
        }

        // TODO: Refactor to actually perform the creation of the channel also. We need to add a TimeSpan parameter to get that going though.
        public static DuplexChannelFactory<ISubProcessProxy> CreateChannelFactory(string serviceName, ISubProcessCallback callbackObject)
        {
            return new DuplexChannelFactory<ISubProcessProxy>(
                callbackObject,
                new NetNamedPipeBinding(),
                new EndpointAddress(serviceName)
            );
        }
    }
}
