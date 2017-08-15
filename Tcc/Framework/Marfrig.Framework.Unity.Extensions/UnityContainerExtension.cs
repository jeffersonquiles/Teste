using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace Tcc.Framework.Unity.Extensions
{
    public static class UnityContainerExtension
    {
        public static void RegisterTypeSingleton<TFrom, TTo>(this IUnityContainer obj) where TTo : TFrom
        {
            LifetimeManager objSingleton = new ContainerControlledLifetimeManager();
            obj.RegisterType<TFrom, TTo>(objSingleton);
        }
    }
}
