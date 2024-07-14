using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System.Diagnostics;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;


namespace AutomationWinFormsTests
{
	public class Session
	{
		protected static RemoteWebDriver? WebDriver { get; set; }

		[SetUp]
		public void Setup()
		{
			var options = new AppiumOptions();

			options.AddAdditionalCapability("app", @"C:\Users\kauan\source\repos\MCypher\Fonts\MCypherWinForms\bin\Debug\net8.0-windows\MCypherWinForms.exe");

			WebDriver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723"), options);
		}

		[TearDown]
		public void TearDown()
		{
			if (WebDriver != null)
			{
				WebDriver.Quit();
				WebDriver.Dispose();
				WebDriver = null;
			}
		}

		[Test]
		public void Teste1()
		{
			Thread.Sleep(2000);
			Assert.Pass();
		}
	}
}