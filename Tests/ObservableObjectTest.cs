using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sniffo.Windows;

namespace Tests
{
    [TestClass]
    public class ObservableObjectTest
    {
        [TestMethod]
        public void PropertyChangedEventHandlerIsRaised()
        {
            var obj = new StubObservableObject();

            var raised = false;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.IsTrue(e.PropertyName == "ChangedProperty");
                raised = true;
            };

            obj.ChangedProperty = "Some Value";

            if (!raised)
                Assert.Fail("PropertyChanged, was never invoked.");
        }

        private class StubObservableObject : ObservableObject
        {
            private string _changedProperty;

            public string ChangedProperty
            {
                get { return _changedProperty; }
                set
                {
                    _changedProperty = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}