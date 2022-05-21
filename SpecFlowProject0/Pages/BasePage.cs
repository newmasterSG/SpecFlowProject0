using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;

namespace SpecFlowProject0.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void implicitWait(long timetoWait) => driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timetoWait);

        public void pageload(long timetoWait)=> driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timetoWait);
    }
}
