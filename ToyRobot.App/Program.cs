using Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace ToyRobot.App
{
	internal static class Program
	{

		public static ServiceProvider ServiceProvider { get; private set; }
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Config();
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			AppDomain.CurrentDomain.UnhandledException +=
		   (sender, args) => HandleUnhandledException(args.ExceptionObject as Exception);
			Application.ThreadException +=
				(sender, args) => HandleUnhandledException(args.Exception);

			Application.Run(new frmToyRobot(ServiceProvider));

			ShutDown();
		}

		static void HandleUnhandledException(Exception e)
		{
			MessageBox.Show(e.Message);
		}

		/// <summary>
		///		Registering the services to the DI container
		/// </summary>
		static void Config()
		{
			ServiceProvider = new ServiceCollection()
				.AddSingleton<IToyRobotService, ToyRobotService>()
				.BuildServiceProvider();
		}

		static void ShutDown()
		{
			ServiceProvider?.Dispose();
		}


	}
}
