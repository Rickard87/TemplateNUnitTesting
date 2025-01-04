using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSEFOS.Paths
{
    internal static class Messages
    {
        //Fields
        public static By AddRecipientFieldCSS { get; } = By.CssSelector("#vs1__combobox .vs__search");
        public static By SubjectFieldID { get; } = By.Id("subject");
        public static By BodyFieldID { get; } = By.Id("messageContent");
        public static By ErrorMessageXPath { get; } = By.XPath("//*[@id=\"noty_layout__bottomCenter\"]");
        public static By SuccessMessageSentXPath { get; } = By.XPath("//div[contains(@class, 'noty_body') and contains(text(), 'Skickat meddelande')]");

        //Buttons
        public static By MessagesButtonLinkText { get; } = By.LinkText("Meddelanden");
        public static By MessagesButtonXPath { get; } = By.XPath("//*[@id=\"menu_messages\"]/a");
        public static By NewMessageButtonXPath { get; } = By.XPath("//*[@id=\"inbox-content\"]/div/form/span/span[1]/button");
        public static By SafeMessageRadioButtonCSS { get; } = By.CssSelector(".mt-2 > .mt-2 > .custom-control-label");
        public static By AbleToRespondSliderCSS { get; } = By.CssSelector(".ml-2 > .custom-switch > .custom-control-label");
        public static By ContinueButtonCSS { get; } = By.CssSelector(".btn-fill");
    }
}
