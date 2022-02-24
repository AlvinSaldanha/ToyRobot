using Microsoft.Extensions.DependencyInjection;
using System;

namespace Domain.XUnitTests
{
	/// <summary>
	///		Base test class to configure the environment (IoC)
	/// </summary>
	public abstract class ConfigureTestEnvironment
	{

		protected IServiceProvider Container { get; }

		/// <summary>
		///		The constructor for initialising IoC
		/// </summary>
		protected ConfigureTestEnvironment()
		{
			var services = new ServiceCollection();
			ConfigureIocContainer(services);
			Container = services.BuildServiceProvider();
		}

		/// <summary>
		///		Configure IoC, register all dependencies
		/// </summary>
		protected virtual void ConfigureIocContainer(IServiceCollection services)
		{
			services.AddTransient<IToyRobotService, ToyRobotService>();
		}
	}
}
