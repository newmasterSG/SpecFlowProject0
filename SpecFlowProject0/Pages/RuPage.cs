using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject0.Pages
{
    public class RuPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'рыба')]")]
        private IWebElement text1;

        private readonly string word1 = "рыба";
        public RuPage(IWebDriver driver) : base(driver)
        { }
        public string text() => text1.Text;

        public string word() => text().Substring(25, 4);

        public string getword1() => word1;
    }
}
