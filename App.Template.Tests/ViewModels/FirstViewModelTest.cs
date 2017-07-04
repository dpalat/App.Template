using App.Template.Tests.Base;
using App.Template.XForms.Core.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace App.Template.Tests.ViewModels
{
    [TestClass]
    public class FirstViewModelTest : BaseTest
    {
        [TestMethod]
        public void Ctor_WithOutAurguments_ShouldIncrementCtorCountPropertyOneTime()
        {
            var viewModel = new FirstViewModel();
            var iterations = new Random().Next(20);
            for (var i = 0; i < iterations; i++)
            {
                viewModel = new FirstViewModel();
            }

            Assert.AreEqual(iterations + 1, viewModel.CtorCount);
        }

        [TestMethod]
        public void ResetCounter_WhenExecuted_ShouldResetCtorCountToZero()
        {
            var viewModel = new FirstViewModel();
            viewModel.ResetCounter();

            Assert.AreEqual(0, viewModel.CtorCount);
        }
    }
}