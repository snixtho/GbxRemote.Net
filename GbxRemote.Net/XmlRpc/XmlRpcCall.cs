﻿using GbxRemoteNet.XmlRpc.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GbxRemoteNet.XmlRpc
{
    /// <summary>
    /// Represents a method call to the XML-RPC server.
    /// </summary>
    public class XmlRpcCall : XmlRpcRequest
    {
        /// <summary>
        /// Creates a new XML-RPC call.
        /// </summary>
        /// <param name="method">Name of the method to call.</param>
        /// <param name="args">Parameters of the call.</param>
        public XmlRpcCall(string method, params XmlRpcBaseType[] args) : base(XmlRpcElementNames.MethodCall)
        {
            XElement methodName = new(XmlRpcElementNames.MethodName, method);
            XElement arguments = new(XmlRpcElementNames.Params);

            // add the arguments with their proper elements
            foreach (XmlRpcBaseType arg in args)
                if (arg != null)
                    arguments.Add(new XElement(XmlRpcElementNames.Param,
                        new XElement(XmlRpcElementNames.Value, arg.GetXml())
                    ));

            MainDocument.Root.Add(methodName);
            MainDocument.Root.Add(arguments);
        }
    }
}
