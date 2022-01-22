using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency.Injection.Scratch.Dependency.Injection
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; }
        public Type ImplementationType { get; }
        public ServiceLifeTime LifeTime { get; }
        public object Implementation { get; internal set; }

        public ServiceDescriptor(
            object implementation, 
            ServiceLifeTime lifetime)
        {
            ServiceType = implementation.GetType();
            Implementation = implementation;
            LifeTime = lifetime;
        }
        public ServiceDescriptor(
            Type serviceType, 
            ServiceLifeTime lifetime)
        {
            ServiceType = serviceType;
            LifeTime = lifetime;
        }
        public ServiceDescriptor(
            Type serviceType, 
            Type implementationType, 
            ServiceLifeTime lifetime)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
            LifeTime = lifetime;
        }
    }
    public enum ServiceLifeTime
    {
        Singleton,
        Scoped,
        Transient
    }
}
