using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace WindowsFormsApp1
{
    public static class WebDriverExtensions
    {
        
        public static void LoadPage(this IWebDriver webDriver,
            TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Navigate().GoToUrl(url);
        }

        public static string GetText(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            return webElement.Text;
        }
                                                                                               
        public static void SetText(this IWebDriver webDriver,
            By by, string text)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.SendKeys(text);
        }

        public static void Submit(this IWebDriver webDriver, By by)
        {
            IWebElement webElement = webDriver.FindElement(by);
            webElement.Submit();
        }

        public static void KillDriversAndBrowsers()
        {
            Process.Start("taskkill", "/f /im IEDriver.exe").WaitForExit();
            Process.Start("taskkill", "/f /im chromedriver.exe").WaitForExit();
            Process.Start("taskkill", "/f /im geckodriver.exe").WaitForExit();
            Process.Start("taskkill", "/f /im iexplore.exe").WaitForExit();
            Process.Start("taskkill", "/f /im chrome.exe").WaitForExit();
            Process.Start("taskkill", "/f /im firefox.exe").WaitForExit();
            //Process.Start("cmd.exe", @"/C DEL /q/f/s %TEMP%\*").WaitForExit();
        }
        public static void KillFirefox()
        {
            Process.Start("taskkill", "/f /im geckodriver.exe").WaitForExit();
            Process.Start("taskkill", "/f /im firefox.exe").WaitForExit();
            //Process.Start("cmd.exe", @"/C DEL /q/f/s %TEMP%\*").WaitForExit();
            
        }
        public static void KillChrome()
        {
            Process.Start("taskkill", "/f /im chromedriver.exe").WaitForExit();
            Process.Start("taskkill", "/f /im chrome.exe").WaitForExit();
        }

        public static Boolean SwitchWindowByTitle(IWebDriver driver, string title)
        {
            var currentWindow = driver.CurrentWindowHandle;
            var availableWindows = new List<string>(driver.WindowHandles);

            foreach (string w in availableWindows)
            {
                if (w != currentWindow)
                {
                    driver.SwitchTo().Window(w);
                    if (driver.Title.Contains(title))
                        return true;
                    else
                    {
                        driver.SwitchTo().Window(currentWindow);
                    }

                }
            }
            return false;
        }

        public static Boolean SwitchWindowByURL(IWebDriver driver, string url)
        {
            var currentWindow = driver.CurrentWindowHandle;
            var availableWindows = new List<string>(driver.WindowHandles);

            foreach (string w in availableWindows)
            {
                if (w != currentWindow)
                {
                    driver.SwitchTo().Window(w);
                    if (driver.Url == url)
                        return true;
                    else
                    {
                        driver.SwitchTo().Window(currentWindow);
                    }

                }
            }
            return false;
        }

        
        public static IWebElement GetPageClickOnNumCartaoContain(IWebDriver driver, string texto)
        {
            IWebElement result = null;
            var links = driver.FindElements(By.TagName("a"));
            string[] num = texto.Replace("******", "|").Split('|');

            foreach (var link in links)
            {
                if (link.Text.Contains(num[0]) && link.Text.Contains(num[1]))
                {
                    result = link;
                    break;
                }

            }
            return result;
        }

        public static void WaitForPageLoad(IWebDriver driver)
        {
            IWebElement page = null;
            if (page != null)
            {
                var waitForCurrentPageToStale = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                waitForCurrentPageToStale.Until(ExpectedConditions.StalenessOf(page));
            }

            var waitForDocumentReady = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitForDocumentReady.Until((wdriver) => (driver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));

            page = driver.FindElement(By.TagName("html"));
            Thread.Sleep(1000);
        }

        public static Boolean getWindowByTitle(IWebDriver driver, string title)
        {
            int timeout = 0;
            Boolean loadPage = false;
            do
            {
                Thread.Sleep(1000);
                loadPage = SwitchWindowByTitle(driver, title);
                timeout++;
            } while (loadPage == false && timeout <= 20);

            return loadPage;
        }

        public static Boolean getWindowByURL(IWebDriver driver, string url)
        {
            int timeout = 0;
            Boolean loadPage = false;
            do
            {
                Thread.Sleep(1000);
                loadPage = SwitchWindowByURL(driver, url);
                timeout++;
            } while (loadPage == false || timeout >= 5);

            return loadPage;
        }
    }
}
