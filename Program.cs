using Gtk;
using GObjectRepro.UI;

namespace GObjectRepro
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();

            var app = new Application("de.saskathex.GObjectRepro", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            var win = MainWindow.Create();
            app.AddWindow(win);

            win.Show();
            Gtk.Application.Run();
        }
    }
}
