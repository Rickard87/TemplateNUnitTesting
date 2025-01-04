using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSEFOS
{
    internal class Perform
    {
        public enum WebElementAction
        {
            Click,
            Clear,
            SendKeys
        }
        public static void ActionOnElement(IWebElement element, WebElementAction[] actions, string? content = null)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element), "The IWebElement cannot be null.");
            }
            if (actions == null || actions.Length == 0)
            {
                throw new ArgumentException("Actions array cannot be null or empty.", nameof(actions));
            }
            foreach (var action in actions)
            {
                switch (action)
                {

                    case WebElementAction.Click:
                        element.Click(); break;
                    case WebElementAction.Clear:
                        element.Clear(); break;
                    case WebElementAction.SendKeys:
                        if (string.IsNullOrEmpty(content))
                        {
                            throw new ArgumentException("Content must be provided for the SendKeys action.");
                        }
                        element.SendKeys(content);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(action), action, null);
                }
            }
        }
    }
}
