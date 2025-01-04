using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSEFOS.Paths
{
    internal static class Meetings
    {
        //Fields
        public static By MeetingRecipientFieldXPath { get; } = By.XPath("//section[@class='w-100 mt-2']//input[@type='search']");
        public static By MeetingSubjectFieldXPath { get; } = By.XPath("//input[@id='subject' and contains(@placeholder, 'Ämne')]");
        public static By MeetingBodyFieldXPath { get; } = By.XPath("//textarea[@placeholder='Detta är ett säkert meddelande och du behöver klicka på \"Öppna meddelande\" för att läsa det.']");
        public static By SuccessMeetingSentXPath { get; } = By.XPath("//div[contains(@class, 'noty_body') and contains(text(), 'Skickat möte')]");

        //Buttons
        public static By MeetingsButtonXPath { get; } = By.XPath("//*[@id=\"sidebar-wrapper\"]/section/div/ul/li[3]/a");
        public static By NewMeetingButtonID { get; } = By.XPath("//button[@aria-haspopup='menu' and contains(@class, 'dropdown-toggle') and text()='Nytt möte']");
        public static By SEFOSMeetingButtonXPath { get; } = By.XPath("//a[@role='menuitem' and contains(@class, 'dropdown-item') and text()=' SEFOS möte']");
        public static By MeetingContinueButtonXPath { get; } = By.XPath("//*[@id=\"add-meeting\"]/div/div/div/div/div/button[2]");
        public static By MeetingSendButtonXPath { get; } = By.XPath("//*[@id=\"add-meeting\"]/div/div/div/div/div/div/button[2]");
    }
}
