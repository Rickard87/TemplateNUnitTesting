using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSEFOS
{
    internal class MeetingTests
    {
        //Helper Values
        private readonly int defaultWaitTime = Helpers.DefaultWaitTime;

        //User values
        private readonly string userEmail = UserConfig.Email;
        private readonly string recipientEmail = Recipient.InternalEmail;
        private readonly string recipientSubject = Recipient.MeetingSubject;
        private readonly string recipientBody = Recipient.MeetingBody;

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
        public void CreateBooking()
        {
            Console.WriteLine("Running CreateBooking test");
            navigations.Meetings();

            //Test
            IWebElement? sefosMeetingButton = helpers.WaitForElement(Paths.Meetings.SEFOSMeetingButtonXPath, defaultWaitTime);
            Perform.ActionOnElement(sefosMeetingButton!, new[] { Perform.WebElementAction.Click });

            IWebElement? meetingRecipientField = helpers.WaitForElement(Paths.Meetings.MeetingRecipientFieldXPath, defaultWaitTime);
            Perform.ActionOnElement(meetingRecipientField!, new[] { Perform.WebElementAction.Clear, Perform.WebElementAction.SendKeys }, recipientEmail);

            IWebElement? meetingSubjectField = helpers.WaitForElement(Paths.Meetings.MeetingSubjectFieldXPath, defaultWaitTime);
            Perform.ActionOnElement(meetingSubjectField!, new[] { Perform.WebElementAction.Clear, Perform.WebElementAction.SendKeys }, recipientSubject);

            IWebElement? meetingBodyField = helpers.WaitForElement(Paths.Meetings.MeetingBodyFieldXPath, defaultWaitTime);
            Perform.ActionOnElement(meetingBodyField!, new[] { Perform.WebElementAction.Clear, Perform.WebElementAction.SendKeys }, recipientBody);

            Thread.Sleep(2000); //Instead of waiting for button to become clickable, just wait 2 seconds
            IWebElement? meetingContinueButton = helpers.WaitForElement(Paths.Meetings.MeetingContinueButtonXPath, defaultWaitTime);
            Perform.ActionOnElement(meetingContinueButton!, new[] { Perform.WebElementAction.Click });

            IWebElement? meetingSendButton = helpers.WaitForElement(Paths.Meetings.MeetingSendButtonXPath, defaultWaitTime);
            Perform.ActionOnElement(meetingSendButton!, new[] { Perform.WebElementAction.Click });

            IWebElement? successMeetingSent = helpers.WaitForElement(Paths.Meetings.SuccessMeetingSentXPath, defaultWaitTime);
            string expected = "Skickat möte";
            string actual = successMeetingSent?.GetAttribute("innerText") ?? "not exist";
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
