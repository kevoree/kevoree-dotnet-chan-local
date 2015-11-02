using System;
using System.Collections.Generic;
using Org.Kevoree.Annotation;
using Org.Kevoree.Core.Api;

namespace Org.Kevoree.Library
{
	[ChannelType]
    [Serializable]
    public class LocalChannel : MarshalByRefObject, DeployUnit, ChannelPort
	{
	    private readonly List<Port> _inputPorts = new List<Port>();

		public LocalChannel ()
		{
		}

        [Dispatch]
		public void dispatch (string payload, Callback callback)
		{
			foreach (var p in _inputPorts) {
				p.send (payload, callback);
			}

		}

	    public void addInputPort(Port p)
	    {
	        this._inputPorts.Add(p);
	    }

	    public void removeInputPort(Port p)
	    {
	        this._inputPorts.Remove(p);
	    }

        public void addRemoteInputPort(Port p)
        {

        }

        public void removeRemoteInputPort(Port p)
        {

        }

	}
}
