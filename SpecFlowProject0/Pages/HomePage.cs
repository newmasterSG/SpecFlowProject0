using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject0.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Pyccкий')]")]
        private IWebElement rupage;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value,'Generate Lorem Ipsum')]")]
        private IWebElement generate;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'amount')]")]
        private IWebElement amountbutton;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'words')]")]
        private IWebElement wordbutton;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'bytes')]")]
        private IWebElement bytesbutton;


        [FindsBy(How = How.XPath, Using = "//input[contains(@type,'checkbox')]")]
        private IWebElement checkboxbutton;

        public HomePage(IWebDriver driver) : base(driver)
        { }

        public bool IsGotoRuPageVisiable() => rupage.Displayed;
        public void clicktorupage() => rupage.Click();
        public bool IsGenerateVisiable() => generate.Displayed;
        public void clickgenerate() => generate.Click();
        public bool IsAmountButtonVisiable() => amountbutton.Displayed;
        public void WriteSomethinkInAmountButton(string amount)
        {
            amountbutton.Clear();
            amountbutton.SendKeys(amount);
        }
        public bool IsWordButtonVisiable() => wordbutton.Displayed;
        public void clickToWordButton() => wordbutton.Click();
        public bool IsBytesButtonVisiable() => bytesbutton.Displayed;
        public void clickToBytesButton() => bytesbutton.Click();
        public bool IsCheckBoxVisiable() => checkboxbutton.Displayed;
        public void clickToCheckBox() => checkboxbutton.Click();
        public void openHomePage(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }
    }
}
