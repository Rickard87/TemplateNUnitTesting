using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSEFOS
{
    internal class MessageTests
    {
        //Helper Values
        private readonly int defaultWaitTime = Helpers.DefaultWaitTime;

        //User values
        private readonly string userEmail = UserConfig.Email;
        private readonly string recipientEmail = Recipient.InternalEmail;
        private readonly string recipientSubject = Recipient.MessageSubject;
        private readonly string recipientBody = Recipient.MessageBody;

        //Objects
        private IWebDriver driver;
        private Helpers helpers;
        private readonly Navigations navigations = new();

        [SetUp]
        public void Setup()
        {
            driver = DriverOptions.GetChromeDriver();
            helpers = new Helpers(driver);
            navigations.Login(driver, userEmail);
        }
        [Test]
        public void SendMessage()
        {
            Console.WriteLine("Running SendMessage test");
            navigations.Messages();

            //Test
            IWebElement? addRecipientField = helpers.WaitForElement(Paths.Messages.AddRecipientFieldCSS, defaultWaitTime);
            Perform.ActionOnElement(addRecipientField!, new[] { Perform.WebElementAction.Clear, Perform.WebElementAction.SendKeys }, recipientEmail);

            IWebElement? subjectField = helpers.WaitForElement(Paths.Messages.SubjectFieldID, defaultWaitTime);
            Perform.ActionOnElement(subjectField!, new[] {Perform.WebElementAction.Clear, Perform.WebElementAction.SendKeys }, recipientSubject);

            IWebElement? bodyField = helpers.WaitForElement(Paths.Messages.BodyFieldID, defaultWaitTime);
            Perform.ActionOnElement(bodyField!, new[] {Perform.WebElementAction.Clear, Perform.WebElementAction.SendKeys }, recipientBody);

            Thread.Sleep(1000);
            IWebElement? continueButton = helpers.WaitForElement(Paths.Messages.ContinueButtonCSS, defaultWaitTime);
            Perform.ActionOnElement(continueButton!, new[] { Perform.WebElementAction.Click });
            Thread.Sleep(1000);

            IWebElement? safeMessageRadioButton = helpers.WaitForElement(Paths.Messages.SafeMessageRadioButtonCSS, defaultWaitTime);
            Perform.ActionOnElement(safeMessageRadioButton!, new[] { Perform.WebElementAction.Click });
            Thread.Sleep(1000);

            IWebElement? ableToRespondSlider = helpers.WaitForElement(Paths.Messages.AbleToRespondSliderCSS, defaultWaitTime);
            Perform.ActionOnElement(ableToRespondSlider!, new[] { Perform.WebElementAction.Click });
            Thread.Sleep(1000);

            IWebElement? sendButton = helpers.WaitForElement(Paths.Messages.ContinueButtonCSS, defaultWaitTime);
            Perform.ActionOnElement(sendButton!, new[] {Perform.WebElementAction.Click});

            IWebElement? successMessageSent = helpers.WaitForElement(Paths.Messages.SuccessMessageSentXPath, defaultWaitTime);
            string expected = "Skickat meddelande";
            string actual = successMessageSent?.GetAttribute("innerText") ?? "not exist";
            Assert.That(actual, Is.EqualTo(expected));
        }
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Disposing");
            driver.Quit();
            driver.Dispose();
        }
    }
}
