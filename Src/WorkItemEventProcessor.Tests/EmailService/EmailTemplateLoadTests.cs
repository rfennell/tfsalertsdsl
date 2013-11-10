﻿
namespace TFSEventsProcessor.Tests
{
    using NUnit.Framework;
    using TFSEventsProcessor.Tests.Helpers;

    [TestFixture]
    public class EmailTemplateLoadTests
    {
       [Test]
        public void Read_the_title_template()
        {
            // arrange
            var contents = TestData.DummyTemplate();
            var template = new EmailTemplate(contents);

            // act
            var actual = template.Title;

            // assert
            Assert.AreEqual("The Work Item @@System.ID@@ has been edited", actual);
        }

       [Test]
        public void Read_the_body_template()
        {
            // arrange
            var contents = TestData.DummyTemplate();
            var template = new EmailTemplate(contents);

            // act
            var actual = template.Body;

            // assert
            Assert.AreEqual("The title is @@System.Title@@ <u>for</u> the @@System.ID@@ by ##System.ChangedBy##", actual);
        }

       [Test]
        public void Read_the_workitem_header_template()
        {
            // arrange
            var contents = TestData.DummyTemplate();
            var template = new EmailTemplate(contents);

            // act
            var actual = template.WiFieldHeader;

            // assert
            Assert.AreEqual("<br /><strong><u>All wi fields in the alert</strong></u>", actual);
        }

       [Test]
        public void Read_the_alertitem_header_template()
        {
            // arrange
            var contents = TestData.DummyTemplate();
            var template = new EmailTemplate(contents);

            // act
            var actual = template.AlertFieldHeader;

            // assert
            Assert.AreEqual("<br /><strong><u>All changed fields in the alert</strong></u>", actual);
        }

       [Test]
       public void Cannot_load_a_missing_template()
       {
           // arrange
         
           // act
           var actual = EmailTemplate.FindTemplate(string.Empty, string.Empty);

           // assert
           Assert.AreEqual(string.Empty, actual);
       }

       [Test]
       public void Can_load_a_specfic_template()
       {
           // arrange

           // act
           var actual = EmailTemplate.FindTemplate(@"dsl\tfs\EmailTemplate.htm", string.Empty);

           // assert
           Assert.AreEqual(@"dsl\tfs\EmailTemplate.htm", actual);
       }

       [Test]
       public void Can_load_a_workitem_template()
       {
           // arrange

           // act
           var actual = EmailTemplate.FindTemplate(@"dsl\tfs", "PBI");

           // assert
           Assert.AreEqual(@"dsl\tfs\PBI.htm", actual);
       }

 
    }
}
