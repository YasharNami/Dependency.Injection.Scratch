

using Dependency.Injection.Scratch.Dependency.Injection;
using Dependency.Injection.Scratch.Services;

var services = new DIServiceCollection();

services.RegisterTransient<ISomeService, SomeServiceOne>();
services.RegisterTransient<IRandomGuidProvider, RandomGuidProvider>();


var container = services.GenerateContainer();

var serviceFirst = container.GetService<ISomeService>();
var serviceSecond = container.GetService<ISomeService>();

serviceFirst.PrintSomthing();
serviceSecond.PrintSomthing();
Console.ReadKey();