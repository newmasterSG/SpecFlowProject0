using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject0.Pages
{
    public class AfterGeneratingPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Lorem ipsum dolor')]")]
        private IWebElement text;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'English')]")]
        private IWebElement go_back;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'lipsum')]")]
        private IWebElement all_text;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Lorem')or contains(text(),'lorem')]")]
        private IList<IWebElement> paragraphscontainslorem;

        private readonly string First_Sentence = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
        public AfterGeneratingPage(IWebDriver driver) : base(driver)
        { }

        public string BeginningOftTextInTheFirstPar() => text.Text.Substring(0, 55);

        public string AllText() => all_text.Text;

        public int WordAfterClickAmount()
        {
            string sentence = text.Text;
            int amountword = sentence.Split(' ').Length;
            return amountword;
        }

        public int BytesAfterClickAmount()
        {

            char[] c = AllText().ToCharArray();
            int amountword = c.Length;
            return amountword;
        }

        public IList<IWebElement> getParagraphsContainsLorem()
        {
            return paragraphscontainslorem;
        }

        public string SearchLoremIpsum() => all_text.Text.Substring(0, 11);

        public int sizeParagraphsContainsLorem()
        {
            return getParagraphsContainsLorem().Count;
        }
        public string First()
        {
            return First_Sentence;
        }
        public bool IsGoBackVisiable() => go_back.Displayed;

        public void clickBack() => go_back.Click();
    }
}
