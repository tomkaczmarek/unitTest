using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.Events
{
    public class Presenter
    {
        private readonly IView _view;

        public Presenter(IView view)
        {
            _view = view;
            this._view.Loaded += OnLoaded;
        }

        private void OnLoaded()
        {
            _view.Render("Hello world");
        }
    }
}
