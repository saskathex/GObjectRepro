using Gtk;
using System;
using System.Reflection;

namespace GObjectRepro.UI
{

    public class MainWindow : Window
    {
        public static MainWindow Create()
        {
            var fullname = MethodBase.GetCurrentMethod().DeclaringType.FullName;
            var builder = new Builder(null, fullname + ".glade", null);
            var window = new MainWindow(builder, builder.GetObject("Window").Handle);

            return window;
        }

        protected MainWindow(Builder builder, IntPtr handle) 
            : base(handle)
        {
            _builder = builder;
            if (_builder != null)
            {
                _builder.Autoconnect(this);
            }

            SetupHandlers();

            this.DeleteEvent += new DeleteEventHandler(OnWindowDelete);
        }

#pragma warning disable 649

        [Builder.Object]
        private readonly Button Button1;

        [Builder.Object]
        private readonly Button Button2;

        [Builder.Object]
        private readonly Notebook RightControlNotebook;

#pragma warning restore 649

        private Builder _builder;

        void OnWindowDelete(object obj, DeleteEventArgs args)
        {
            Gtk.Application.Quit();
            args.RetVal = true;
        }

        protected void SetupHandlers()
        {
            DeleteEvent += OnLocalDeleteEvent;
            Button1.Clicked += Button1_Clicked;
            Button2.Clicked += Button2_Clicked;
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            FillNotebook(count: 2);
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            FillNotebook(count: 4);
        }

        private void FillNotebook(int count)
        {
            for (int i = RightControlNotebook.NPages - 1; i >= 0; i--)
            {
                var widget = RightControlNotebook.GetNthPage(i);
                widget.Dispose();
                RightControlNotebook.RemovePage(i);
            }

            for (int i = 0; i < count; i++)
            {
                if (i % 2 == 0)
                {
                    var frame1 = Frame1.Create();
                    RightControlNotebook.AppendPage(frame1, new Gtk.Label($"Page {i+1}"));
                }
                else
                {
                    var frame2 = Frame2.Create();
                    RightControlNotebook.AppendPage(frame2, new Gtk.Label($"Page {i+1}"));
                }
            }
            RightControlNotebook.ShowAll();
        }

        protected void OnLocalDeleteEvent(object sender, DeleteEventArgs a)
        {
            OnExitApplication();
            a.RetVal = true;
        }

        public void OnExitApplication()
        {
            Application.Quit();
        }
    }
}
