namespace Tests
{
    using Core;

    using Microsoft.AspNetCore.Mvc;

    using Moq;

    using NUnit.Framework;

    using Web.Controllers;

    [TestFixture]
    public class EditOwnerControllerTests
    {
        private Mock<IAccountService> _accountService;

        [SetUp]
        public void Setup()
        {
            _accountService = new Mock<IAccountService>();
        }

        [Test]
        public void TestMethod_IsActionResult()
        {
            var _editOwnerController = new EditOwnerController(_accountService.Object);
            var result = _editOwnerController.Index();
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void TestMethod_IsRedirectToActionResult()
        {
            var _editOwnerController = new EditOwnerController(_accountService.Object);
            var result = _editOwnerController.Index();
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }

        [Test]
        public void TestMethod_IsRedirectToHomeController()
        {
            var _editOwnerController = new EditOwnerController(_accountService.Object);
            var result = (RedirectToActionResult)_editOwnerController.Index();
            Assert.AreEqual("Home", result.ControllerName);
            Assert.AreEqual("Index", result.ActionName);
        }
    }
}
