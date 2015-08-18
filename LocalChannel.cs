using System;
using Org.Kevoree.Annotation;
using Org.Kevoree.Core.Api;

namespace kevoreedotnetchannellocal
{
	[ChannelType]
	public class LocalChannel:ChannelDispatch
	{
		[KevoreeInject]
		private ChannelContext channelContext;

		public LocalChannel ()
		{
		}

		#region ChannelDispatch implementation

		void ChannelDispatch.dispatch (string payload, Callback callback)
		{
			foreach (var p in channelContext.getLocalPorts()) {
				p.send (payload, callback);
			}
		}

		#endregion
	}
}
