using NUnit.Framework;

namespace M8_Dzianis_Dukhnou
{
    [TestFixture]
    public class TestSendEmail : BaseTest
    {
        string emailTo;
        string subject;
        string message;

        [SetUp]
        public void TestSendEmail_SetUp()
        {
            emailTo = "dzianis.dukhnou@thomsonreuters.com";
            subject = method.GetRandomString(10);
            message = method.GetRandomString(99);
        }

        [TearDown]
        public void TestSendEmail_TearDown()
        {
            _sentPage = _homePage.OpenSentLetters();
            _sentPage.DeleteAll();
        }

        [Test]
        public void SendingDraftEmail_CheckDraftFolder()
        {
            //Arrange
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(emailTo, subject, message);
            _letterPage.CloseLetter();
            _draftPage = _homePage.OpenDraftLetters();

            //Act
            _letterPage = _draftPage.OpenLetterByOrder(1);
            _homePage = _letterPage.ClickSend();

            //Assert
            _draftPage = _homePage.OpenDraftLetters();
            Assert.IsFalse(_draftPage.FindLetterBySubject(subject), "The letter is still in the draft folder");
        }

        [Test]
        public void SendingDraftEmail_CheckSentFolder()
        {
            //Arrange
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(emailTo, subject, message);
            _letterPage.CloseLetter();
            _draftPage = _homePage.OpenDraftLetters();

            //Act
            _letterPage = _draftPage.OpenLetterByOrder(1);
            _homePage = _letterPage.ClickSend();

            //Assert
            _sentPage = _homePage.OpenSentLetters();
            Assert.IsTrue(_draftPage.FindLetterBySubject(subject), "The letter is not in the Sent Folder");
        }
    }
}