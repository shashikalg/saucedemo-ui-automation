using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace saucedemo_ui_automation.Tests;

public class TestBase
{
    protected IWebDriver webDriver;

    [OneTimeSetUp]
    public void InitializeWebDriver()
    {
        webDriver = new ChromeDriver();
    }
}

