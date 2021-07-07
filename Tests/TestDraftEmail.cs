using NUnit.Framework;

namespace M8_Dzianis_Dukhnou
{
    [TestFixture]
    public class TestDraftEmail : BaseTest
    {
        string emailTo;
        string subject;
        string message;

        [SetUp]
        public void TestDraftEmail_SetUp()
        {
            emailTo = "dzianis.dukhnou@thomsonreuters.com";
            subject = method.GetRandomString(10);
            message = method.GetRandomString(50);
        }

        [TearDown]
        public void TestDraftEmail_TearDown()
        {
            _draftPage = _homePage.OpenDraftLetters();
            _draftPage.DeleteAll();
        }

        [Test]
        public void CreatingDraftEmail_VerifyDarftFolder()
        {
            //Act
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(emailTo, subject, message);
            _letterPage.CloseLetter();

            //Assert
            _draftPage = _homePage.OpenDraftLetters();
            Assert.IsTrue(_draftPage.FindLetterBySubject(subject), "The letter is not in the draft folder");
        }

        [Test]
        public void CreatingDraftEmail_VerifyContent()
        {
            //Act
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(emailTo, subject, message);
            _letterPage.CloseLetter();

            //Assert
            _draftPage = _homePage.OpenDraftLetters();
            _letterPage = _draftPage.OpenLetterByOrder(1);

            Assert.AreEqual(emailTo, _letterPage.GetToField(), $"The Field TO doesn't have <{emailTo}>");
            Assert.AreEqual(subject, _letterPage.GetSubjectField(), $"The Field Subject doesn't have <{subject}>");
            Assert.AreEqual(message, _letterPage.GetMessageField(), $"The Field Message doesn't have <{message}>");
        }
    }
}