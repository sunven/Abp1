using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace TransparentProxyDemo
{
    public class ClientProxy : RealProxy, IRemotingTypeInfo
    {
        private readonly Type _proxyType;

        private readonly List<string> _unProxyMethods = new List<string>
        {
            "InitContext",
            "Dispose",
        };

        public ClientProxy(Type proxyType) :
            base(proxyType)
        {
            _proxyType = proxyType;
        }

        public bool CanCastTo(Type fromType, object o)
        {
            return fromType == _proxyType || fromType.IsAssignableFrom(_proxyType);
        }

        public string TypeName { get { return _proxyType.Name; } set { } }


        private static readonly ConcurrentDictionary<Type, List<MethodInfo>> TypeMethodCache = new ConcurrentDictionary<Type, List<MethodInfo>>();
        private List<MethodInfo> GetMethods(Type type)
        {
            return TypeMethodCache.GetOrAdd(type, item =>
            {
                var methods = new List<MethodInfo>(type.GetMethods());
                foreach (var interf in type.GetInterfaces())
                {
                    foreach (var method in interf.GetMethods())
                        if (!methods.Contains(method))
                            methods.Add(method);
                }
                return methods;

            });
        }


        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage methodMessage = new MethodCallMessageWrapper((IMethodCallMessage)msg);
            var methodInfo = GetMethods(_proxyType).FirstOrDefault(item => item.ToString() == methodMessage.MethodBase.ToString());
            object objReturnValue = null;
            if (methodMessage.MethodName.Equals("GetType") && (methodMessage.ArgCount == 0))
            {
                objReturnValue = _proxyType;
            }
            else if (methodInfo != null)
            {
                if (methodInfo.Name.Equals("Equals")
                    || methodInfo.Name.Equals("GetHashCode")
                    || methodInfo.Name.Equals("ToString")
                    || methodInfo.Name.Equals("GetType"))
                {

                    throw new Exception();
                }
                if (_unProxyMethods.All(item => item != methodInfo.Name))
                {
                    objReturnValue = methodInfo.Name + "abc";
                }
            }
            return new ReturnMessage(objReturnValue, methodMessage.Args, methodMessage.ArgCount,
                methodMessage.LogicalCallContext, methodMessage);
        }

    }
}
