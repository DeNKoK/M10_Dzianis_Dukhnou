using NUnit.Framework;

namespace M8_Dzianis_Dukhnou
{
    [TestFixture]
    public class TestRightClick : BaseTest
    {
        string emailTo;
        string subject;
        string message;

        [SetUp]
        public void TestRightClick_SetUp()
        {
            emailTo = "dzianis.dukhnou@thomsonreuters.com";
            subject = method.GetRandomString(10);
            message = method.GetRandomString(100);
        }

        [TearDown]
        public void TestRightClick_TearDown()
        {
            _inboxPage = _homePage.OpenInboxLetters();
            _inboxPage.DeleteAll();
        }

        [Test]
        public void MoveLetterFromDraftToInbox_VerifyDraftFolder()
        {
            //Arrange
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(emailTo, subject, message);
            _letterPage.CloseLetter();

            //Act
            _draftPage = _homePage.OpenDraftLetters();
            _rightClickMenuPage = _draftPage.RightClickOnTheletter(1);
            _rightClickMenuPage.MoveToInboxFolder();

            //Assert
            Assert.IsFalse(_draftPage.FindLetterBySubject(subject), "The Letter is still in the draft folder");
        }

        [Test]
        public void MoveLetterFromDraftToInput_VerifyInputFolder()
        {
            //Arrange
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(emailTo, subject, message);
            _letterPage.CloseLetter();

            //Act
            _draftPage = _homePage.OpenDraftLetters();
            _rightClickMenuPage = _draftPage.RightClickOnTheletter(1);
            _rightClickMenuPage.MoveToInboxFolder();
            _inboxPage = _draftPage.BackToTheInboxFolder();

            //Assert
            Assert.IsTrue(_inboxPage.FindLetterBySubject(subject), "The Letter is not in the inbox folder");
        }
    }
}