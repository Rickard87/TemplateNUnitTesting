using OpenQA.Selenium;

namespace TestSEFOS
{
    internal class Navigations
    {
        //Helper Values
        private readonly int defaultWaitTime = Helpers.DefaultWaitTime;

        Helpers? helpers;
        public void Login(IWebDriver driver, string userEmail)
        {
            helpers = new Helpers(driver);
            driver.Navigate().GoToUrl(UserConfig.LoginURL);
            Thread.Sleep(2000);

            IWebElement? emailField = helpers?.WaitForElement(Paths.Login.EmailFieldID, defaultWaitTime);
            IWebElement? loginButton = helpers?.WaitForElement(Paths.Login.LoginButtonXPath, defaultWaitTime);

            Perform.ActionOnElement(emailField!, new[] { Perform.WebElementAction.Clear, Perform.WebElementAction.SendKeys }, userEmail);
            Perform.ActionOnElement(loginButton!, new[] { Perform.WebElementAction.Click });
        }
        public void Messages()
        {
            IWebElement? messagesButton = helpers!.WaitForElement(Paths.Messages.MessagesButtonLinkText, defaultWaitTime);
            Perform.ActionOnElement(messagesButton!, new[] { Perform.WebElementAction.Click });

            IWebElement? newMessageButton = helpers!.WaitForElement(Paths.Messages.NewMessageButtonXPath, defaultWaitTime);
            Perform.ActionOnElement(newMessageButton!, new[] { Perform.WebElementAction.Click });
        }
        public void Meetings()
        {
            IWebElement? meetingsButton = helpers!.WaitForElement(Paths.Meetings.MeetingsButtonXPath, defaultWaitTime);
            Perform.ActionOnElement(meetingsButton!, new[] { Perform.WebElementAction.Click });

            IWebElement? newMeetingsButton = helpers!.WaitForElement(Paths.Meetings.NewMeetingButtonID, defaultWaitTime);
            Perform.ActionOnElement(newMeetingsButton!, new[] { Perform.WebElementAction.Click });
        }
    }
}
