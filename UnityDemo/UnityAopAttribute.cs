using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace UnityDemo
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Interface)]
    public class UnityAopAttribute : HandlerAttribute, ICallHandler
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return this;
        }


        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var s = new Stopwatch();
            s.Start();
            var result = getNext()(input, getNext);
            s.Stop();
            WriteLog("性能监控->完整方法：{3},方法：{0},参数：{1},耗时：{2}",
                input.MethodBase.Name, JsonConvert.SerializeObject(input.Arguments), s.ElapsedTicks,
                input.MethodBase);
            return result;
        }

        private void WriteLog(string format, params object[] arg)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "\\log.txt";
            File.AppendAllText(path, string.Format(format, arg) + "\r\n");
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute => false;
    }
}