using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowProject0.Hooks;
using SpecFlowProject0.Drivers;
using SpecFlowProject0.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System;
using SpecFlow.Assist;

namespace SpecFlowProject0.Steps
{
    [Binding]
    public sealed class LoremIpsumStepDefinitions:LoremIpsumDriver
    {
        private LoremIpsumDriver loremIpsum;
        private HomePage homePage;
        private AfterGeneratingPage afterGeneratingPage;
        private RuPage ruPage;
        public LoremIpsumStepDefinitions(LoremIpsumDriver ipsumDriver)
        {
            loremIpsum = ipsumDriver;
            homePage = new HomePage(loremIpsum.Driver);
            afterGeneratingPage = new AfterGeneratingPage(loremIpsum.Driver);
            ruPage = new RuPage(loremIpsum.Driver);
        }

        [Given("Go to (.*)")]
        public void GoToURL(string URL)
        {
            homePage.openHomePage(URL);
        }
        [When("Switch to Russian language using one of the links")]
        public void switchRuPage()
        {
            homePage.clicktorupage();
        }
        [Then("Verify that the text of the first element, which is the first paragraph, contains the word")]
        public void verifyword()
        {
            Assert.AreEqual(ruPage.getword1(), ruPage.word());
        }
        [When("Press “Generate Lorem Ipsum")]
        public void clickGenerate()
        {
            homePage.clickgenerate();
            afterGeneratingPage.pageload(30);
        }
        [Then("Verify that the first paragraph starts with 'Lorem ipsum dolor sit amet, consectetur adipiscing elit'")]
        public void verifySentence()
        {
            Assert.AreEqual(afterGeneratingPage.First(), afterGeneratingPage.BeginningOftTextInTheFirstPar());
        }
        [Given("Use field word field")]
        public void VerifyandClickwordbutton()
        {
            homePage.IsWordButtonVisiable();
            homePage.clickToWordButton();
        }
        [Given("Input (.*) into the number field")]
        public void WriteNumber(string number)
        {
            homePage.IsAmountButtonVisiable();
            homePage.WriteSomethinkInAmountButton(number);
        }
        [When("Go Back")]
        public void go_back()
        {
            afterGeneratingPage.IsGoBackVisiable();
            afterGeneratingPage.clickBack();
            homePage.pageload(30);
        }
        [When("Verify correct generation for (.*)")]
        public void checkForanotherAmount(string num)
        {
            int number = Convert.ToInt32(num);
                if (number <= 0)
                    Assert.AreNotEqual(number, afterGeneratingPage.WordAfterClickAmount());
                else
                { 
                    Assert.AreEqual(number, afterGeneratingPage.WordAfterClickAmount());
                }
        }
        [When("Use field word field")]
        public void clickwordbutton()
        {
            homePage.clickToWordButton();
        }
        [When("Input (.*) into the number field")]
        public void Write(string number)
        {
            homePage.WriteSomethinkInAmountButton(number);
        }
        [Then("Use field bytes")]
        public void Verifyandclickbytes()
        {
            homePage.IsBytesButtonVisiable();
            homePage.clickToBytesButton();
        }
        [Then("Input (.*) into the number field")]
        public void WriteNum(string number)
        {
            homePage.WriteSomethinkInAmountButton(number);
        }
        [Then("Press “Generate Lorem Ipsum")]
        public void Generate()
        {
            homePage.clickgenerate();
            afterGeneratingPage.pageload(30);
        }
        [Then("Verify correct generation for (.*)")]
        public void checkForAmount(string num)
        {
            int number = Convert.ToInt32(num);
            if (number <= 0)
                Assert.AreNotEqual(number, afterGeneratingPage.BytesAfterClickAmount());
            else
            {
                Assert.AreEqual(number, afterGeneratingPage.BytesAfterClickAmount());
            }
        }
        [Then("Go Back")]
        public void goback()
        {
            afterGeneratingPage.clickBack();
            homePage.pageload(30);
        }
        [Given("Uncheck start with Lorem Ipsum checkbox")]
        public void clickUncheck()
        {
            homePage.IsCheckBoxVisiable();
            homePage.clickToCheckBox();
        }
        [Then("Verify that result no longer starts with (.*)")]
        public void checkWithoutLorem(string sentence)
        {
            sentence = "Lorem ipsum";
            Assert.AreNotEqual(sentence, afterGeneratingPage.SearchLoremIpsum());
        }
        [Then("Run the generation (.*) times and get the average number of paragraphs containing the word (.*)")]
        public void check_word(int time,string word)
        {
            int MatchCounter = 0;
            for (int i = 0; i < time; i++)
            {
                MatchCounter += afterGeneratingPage.sizeParagraphsContainsLorem();
                afterGeneratingPage.clickBack();
                homePage.clickgenerate();
                Assert.IsTrue(MatchCounter / 50 < 0.6);
            }

        }
    }
}
