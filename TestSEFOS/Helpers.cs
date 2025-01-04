using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSEFOS
{
    public class Helpers
    {
        public static int DefaultWaitTime { get; set; } = 15;
        private readonly IWebDriver driver;

        public Helpers(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true; // Element found
            }
            catch (NoSuchElementException)
            {
                return false; // Element not found
            }
        }
        public IWebElement? WaitForElement(By by, int waitSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));

            try
            {
                // Use a lambda expression to wait until the element is present
                IWebElement? element = wait.Until(d =>
                {
                    try
                    {
                        return d.FindElement(by); // Try to find the element using the provided locator
                    }
                    catch (NoSuchElementException)
                    {
                        return null; // If not found, return null to keep waiting
                    }
                });

                return element; // Return the found element
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Element with locator '{by}' was not found within the timeout period.");
                return null; // Return null if the element is not found within the timeout
            }
        }
        public string GenerateRandomString(int minLength = 7, int maxLength = 10)
        {
            Random random = new();

            // Define the characters to choose from (letters and numbers)
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            int length = random.Next(minLength, maxLength + 1);

            char[] stringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

    }
}
