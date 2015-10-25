using System;
using System.Collections.Generic;
using Org.Kevoree.Annotation;
using Org.Kevoree.Core.Api;

namespace Org.Kevoree.Library
{
	[ChannelType]
    [Serializable]
    public class LocalChannel : MarshalByRefObject, DeployUnit, ChannelDispatch
	{
	    private List<Port> _inputPorts = new List<Port>();

		public LocalChannel ()
		{
		}

		#region ChannelDispatch implementation

		void ChannelDispatch.dispatch (string payload, Callback callback)
		{
			foreach (var p in _inputPorts) {
				p.send (payload, callback);
			}

		}

	    public void registerPort(Port p)
	    {
	        this._inputPorts.Add(p);
	    }

	    public void removePort(Port p)
	    {
	        this._inputPorts.Remove(p);
	    }

	    #endregion
	}
}
