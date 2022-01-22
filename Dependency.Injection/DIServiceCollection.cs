using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency.Injection.Scratch.Dependency.Injection
{
    public class DIServiceCollection
    {
        private List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();


        public void RegisterSingleton<TService>() =>
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Singleton));

        public void RegisterSingleton<TService>(TService implementation) =>
            _serviceDescriptors.Add(new ServiceDescriptor(implementation, ServiceLifeTime.Singleton));

        public void RegisterTransient<TService>() =>
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Transient));

        public void RegisterTransient<TService>(TService implementation) => 
            _serviceDescriptors.Add(new ServiceDescriptor(implementation, ServiceLifeTime.Transient));

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService =>
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Transient));



        public DIContainer GenerateContainer() => new DIContainer(_serviceDescriptors);

    }
}
