using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using LogAn;
using LogAn.Events;

namespace LogAnWithSubstitute.UnitTests
{
    [TestFixture]
    public class EventRelatedTests
    {

        [Test]
        public void ctor_WhenViewIsLoaded_CallsViewRender()
        {
            IView mockView = Substitute.For<IView>();

            Presenter presenter = new Presenter(mockView);

            mockView.Loaded += Raise.Event<Action>();

            mockView.Received().Render(Arg.Is<string>(s => s.Contains("Hello world")));
        }

    }
}
