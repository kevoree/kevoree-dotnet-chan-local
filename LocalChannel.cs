using System;
using Org.Kevoree.Annotation;
using Org.Kevoree.Core.Api;

namespace Org.Kevoree.Channel.Local
{
	[ChannelType]
    [Serializable]
    public class LocalChannel : MarshalByRefObject, DeployUnit, ChannelDispatch
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
