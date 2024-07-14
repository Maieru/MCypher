using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutomationWinFormsTest
{
	public class Session
	{
		protected static RemoteWebDriver? Driver { get; set; }

		public static void Setup()
		{
			var dc = new DesiredCapabilities();

			dc.SetCapability("app", @"C:\Users\kauan\source\repos\MCypher\Fonts\MCypherWinForms\bin\Debug\net8.0-windows\MCypherWinForms.exe");

			Driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);
		}

		public static void TearDown()
		{
			if (Driver != null)
			{
				Driver.Quit();
				Driver.Dispose();
			}
		}
	}
}