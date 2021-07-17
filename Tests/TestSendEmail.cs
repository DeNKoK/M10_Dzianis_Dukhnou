using NUnit.Framework;

namespace M8_Dzianis_Dukhnou.Tests
{
    [TestFixture]
    public class TestSendEmail : BaseTest
    {

        [SetUp]
        public void TestSendEmail_SetUp()
        {
            letter = new Entities.Letter(
                "dzianis.dukhnou@thomsonreuters.com",
                randomString.GetRandomString(10),
                randomString.GetRandomString(99)
                );
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
            _letterPage.PopulateEmail(letter);
            _letterPage.CloseLetter();

            //Act
            _draftPage = _homePage.OpenDraftLetters();
            _letterPage = _draftPage.OpenLetterByOrder(1);
            _homePage = _letterPage.ClickSend();

            //Assert
            _draftPage = _homePage.OpenDraftLetters();
            Assert.IsFalse(_draftPage.FindLetterBySubject(letter._subject), "The letter is still in the draft folder");
        }

        [Test]
        public void SendingDraftEmail_CheckSentFolder()
        {
            //Arrange
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(letter);
            _letterPage.CloseLetter();

            //Act
            _draftPage = _homePage.OpenDraftLetters();
            _letterPage = _draftPage.OpenLetterByOrder(1);
            _homePage = _letterPage.ClickSend();

            //Assert
            _sentPage = _homePage.OpenSentLetters();
            Assert.IsTrue(_draftPage.FindLetterBySubject(letter._subject), "The letter is not in the Sent Folder");
        }
    }
}