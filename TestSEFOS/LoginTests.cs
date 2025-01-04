using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestSEFOS
{
    internal class LoginTests
    {
        //Helper Values
        private readonly int defaultWaitTime = Helpers.DefaultWaitTime;

        //User values
        private readonly string userEmail = UserConfig.Email;
        private readonly string otherUserEmail = UserConfig.OtherUserEmail;

        //Objects
        private IWebDriver driver;
        private Helpers helpers;
        private readonly Navigations navigations = new();

        [SetUp]
        public void Setup()
        {
            driver = DriverOptions.GetChromeDriver();
            helpers = new Helpers(driver);
        }

        [Test]
        public void LoginSEFOS()
        {
            Console.WriteLine("Running LoginSEFOS test");
            navigations.Login(driver, userEmail);

            IWebElement? messagesButton = helpers.WaitForElement(Paths.Messages.MessagesButtonXPath, defaultWaitTime);

            string expected = "Meddelanden";
            string actual = messagesButton?.GetAttribute("innerText").Trim() ?? "not exist";
            //Assert.IsNotNull(messagesButton);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FailLoginSEFOS()
        {
            Console.WriteLine("Running FailLoginSEFOS test");

            //Test
            navigations.Login(driver, "22" + userEmail);
            IWebElement? errorMessage = helpers.WaitForElement(Paths.Login.ErrorMessageXPath, defaultWaitTime);
            string expected = "Kan inte logga in med denna informationen. Se till att du skriver rätt information.";
            string actual = errorMessage?.GetAttribute("innerText") ?? "not exist";
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void FailLoginSEFOSOtherUser()
        {
            Console.WriteLine("Running FailLoginSEFOSOtherUser test");

            //Test
            navigations.Login(driver, otherUserEmail);
            IWebElement? errorMessage = helpers.WaitForElement(Paths.Login.ErrorMessageXPath, defaultWaitTime);
            string expected = "Kan inte logga in med denna informationen. Se till att du skriver rätt information.";
            string actual = errorMessage?.GetAttribute("innerText") ?? "not exist";
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                Console.WriteLine("Disposing");
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}