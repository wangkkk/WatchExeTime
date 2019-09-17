using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WatchExeTime.Factory
{
    /// <summary>
    /// 泛型单例基类
    /// </summary>
    public abstract class Singleton<TEntity> where TEntity : class
    {
        private static readonly Lazy<TEntity> _instance
            = new Lazy<TEntity>(() =>
            {
                var ctors = typeof(TEntity).GetConstructors(
                    BindingFlags.Instance
                    | BindingFlags.NonPublic
                    | BindingFlags.Public);
                if (ctors.Count() != 1)
                    throw new InvalidOperationException(String.Format("Type {0} must have exactly one constructor.", typeof(TEntity)));
                var ctor = ctors.SingleOrDefault(c => c.GetParameters().Count() == 0);
                if (ctor == null)
                    throw new InvalidOperationException(String.Format("The constructor for {0} must be private and take no parameters.", typeof(TEntity)));
                return (TEntity)ctor.Invoke(null);
            });

        public static TEntity Instance
        {
            get { return _instance.Value; }
        }
    }
}
