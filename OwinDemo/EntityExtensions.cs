using System;
using System.Reflection;

namespace OwinDemo
{
    /// <summary>
    /// 帮助方法
    /// </summary>
    public static class EntityExtensions
    {
        /// <summary>
        /// 执行方法 公有/私有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T ExecuteMethod<T>(this object instance, string name, params object[] param)
        {
            var type = instance.GetType();
            var method = type.GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (method == null)
            {
                throw new Exception();
            }
            return (T)method.Invoke(instance, param);
        }

        /// <summary>
        /// 执行父类的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="parentType"></param>
        /// <param name="name"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T ExecuteParentMethod<T>(this object instance, Type parentType, string name, params object[] param)
        {
            var method = parentType.GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            if (method == null)
            {
                throw new Exception();
            }
            return (T)method.Invoke(instance, param);
        }
    }
}
