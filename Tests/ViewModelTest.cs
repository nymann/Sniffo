﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sniffo.Windows;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tests
{
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void IsAbstractBaseClass()
        {
            var t = typeof(ViewModel);

            Assert.IsTrue(t.IsAbstract);
        }

        [TestMethod]
        public void IsIDataErrorInfo()
        {
            Assert.IsTrue(typeof(IDataErrorInfo).IsAssignableFrom(typeof(ViewModel)));
        }

        [TestMethod]
        public void IsObservableObject()
        {
            Assert.IsTrue(typeof(ViewModel).BaseType == typeof(ObservableObject));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void IDataErrorInfo_ErrorProperty_IsNotSupported()
        {
            var viewModel = new StubViewModel();
            var value = viewModel.Error;
        }

        [TestMethod]
        public void IndexerPropertyValidatesPropertyNameWithInvalidValue()
        {
            var viewModel = new StubViewModel();
            Assert.IsNotNull(viewModel["RequiredProperty"]);

        }

        [TestMethod]
        public void IndexerPropertyValidatesPropertyNameWithValidValue()
        {
            var viewModel = new StubViewModel
            {
                RequiredProperty = "Some Value"
            };
            Assert.IsNull(viewModel["RequiredProperty"]);
        }

        private class StubViewModel : ViewModel
        {
            [Required]
            public string RequiredProperty { get; set; }
        }
    }
}
