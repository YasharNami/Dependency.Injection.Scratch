using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency.Injection.Scratch.Dependency.Injection
{
    public class DIContainer
    {
        private List<ServiceDescriptor> _serviceDescriptors;
        public DIContainer(List<ServiceDescriptor> serviceDescriptors) => _serviceDescriptors = serviceDescriptors;


        public object GetService(Type ServiceType)
        {
            var descriptor = _serviceDescriptors
                .SingleOrDefault(x => x.ServiceType == ServiceType);

            if (descriptor == null)
                throw new Exception($"Serice of type {ServiceType.Name} isn't registered");

            if (descriptor.Implementation != null)
                return descriptor.Implementation;

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
                throw new Exception($"Cannot instantiate abstract classes or interfaces");

            var constructorInfo = actualType.GetConstructors().First();

            var parametes = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();

            var implementation = Activator.CreateInstance(actualType, parametes);

            if (descriptor.LifeTime == ServiceLifeTime.Singleton)
                descriptor.Implementation = implementation;

            return implementation;
        }

        public T GetService<T>() => (T)GetService(typeof(T));
    }
}
