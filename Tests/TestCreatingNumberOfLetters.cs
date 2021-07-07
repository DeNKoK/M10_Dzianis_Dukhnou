using NUnit.Framework;

namespace M8_Dzianis_Dukhnou
{
    [TestFixture]
    public class TestCreatingNumberOfLetters : BaseTest
    {
        string emailTo;
        string subject;
        string message;

        [SetUp]
        public void TestCreatingNumberOfLetters_SetUp()
        {
            emailTo = "dzianis.dukhnou@thomsonreuters.com";
            subject = method.GetRandomString(10);
            message = method.GetRandomString(50);
        }

        [TearDown]
        public void TestCreatingNumberOfLetters_TearDown()
        {
            _draftPage.DeleteAll();
        }

        [TestCase(11)]
        public void CreatingNumberOfDraftLetters_VerifyRightClickDelete(int number)
        {
            //Act
            _homePage.CreateNumberOfDraftLetters(number, emailTo, subject, message);
            _draftPage = _homePage.OpenDraftLetters();
            _rightClickMenuPage = _draftPage.RightClickOnTheletter(10);
            _draftPage = _rightClickMenuPage.Delete();

            //Assert
            Assert.AreEqual(number - 1, _draftPage.CountDraftLetters(),
                "The count of draft letters was not decreased after deleting one letter");
        }
        
        [TestCase(5)]
        public void CreatingNumberOfDraftLetters_VerifyMoveUpButton(int number)
        {
            //Act
            _homePage.CreateNumberOfDraftLetters(number, emailTo, subject, message);
            _draftPage = _homePage.OpenDraftLetters();
            _draftPage.Scroll(200);

            //Assert
            Assert.IsTrue(_draftPage.FindMoveUpButton(), "The MoveUp button doesn't appear");
        }
    }
}