using NUnit.Framework;

namespace M8_Dzianis_Dukhnou.Tests
{
    [TestFixture]
    public class TestDraftEmail : BaseTest
    {

        [SetUp]
        public void TestDraftEmail_SetUp()
        {
            letter = new Entities.Letter(
                "dzianis.dukhnou@thomsonreuters.com",
                method.GetRandomString(10),
                method.GetRandomString(50)
                );
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
            _letterPage.PopulateEmail(letter);
            _letterPage.CloseLetter();

            //Assert
            _draftPage = _homePage.OpenDraftLetters();
            Assert.IsTrue(_draftPage.FindLetterBySubject(letter._subject), "The letter is not in the draft folder");
        }

        [Test]
        public void CreatingDraftEmail_VerifyContent()
        {
            //Act
            _letterPage = _homePage.CreateNewLetter();
            _letterPage.PopulateEmail(letter);
            _letterPage.CloseLetter();

            //Assert
            _draftPage = _homePage.OpenDraftLetters();
            _letterPage = _draftPage.OpenLetterByOrder(1);

            Assert.AreEqual(letter._emailTo, _letterPage.GetToField(), $"The Field TO doesn't have <{letter._emailTo}>");
            Assert.AreEqual(letter._subject, _letterPage.GetSubjectField(), $"The Field Subject doesn't have <{letter._subject}>");
            Assert.AreEqual(letter._message, _letterPage.GetMessageField(), $"The Field Message doesn't have <{letter._message}>");
        }
    }
}