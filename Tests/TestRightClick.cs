using NUnit.Framework;

namespace M8_Dzianis_Dukhnou.Tests
{
    [TestFixture]
    public class TestRightClick : BaseTest
    {

        [SetUp]
        public void TestRightClick_SetUp()
        {
            letter = new Entities.Letter(
                "dzianis.dukhnou@thomsonreuters.com",
                randomString.GetRandomString(15),
                randomString.GetRandomString(100)
                );
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
            _letterPage.PopulateEmail(letter);
            _letterPage.CloseLetter();

            //Act
            _draftPage = _homePage.OpenDraftLetters();
            _rightClickMenuPage = _draftPage.RightClickOnTheletter(1);
            _rightClickMenuPage.MoveToInboxFolder();

            //Assert
            Assert.IsFalse(_draftPage.FindLetterBySubject(letter._subject), "The Letter is still in the draft folder");
        }

        [Test]
        public void MoveLetterFromDraftToInput_VerifyInputFolder()
        {
            //Arrange
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(letter);
            _letterPage.CloseLetter();

            //Act
            _draftPage = _homePage.OpenDraftLetters();
            _rightClickMenuPage = _draftPage.RightClickOnTheletter(1);
            _rightClickMenuPage.MoveToInboxFolder();
            _inboxPage = _draftPage.BackToTheInboxFolder();

            //Assert
            Assert.IsTrue(_inboxPage.FindLetterBySubject(letter._subject), "The Letter is not in the inbox folder");
        }
    }
}