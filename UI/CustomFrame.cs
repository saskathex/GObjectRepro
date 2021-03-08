using Gtk;
using System;
using System.Diagnostics;

namespace GObjectRepro.UI
{
    public abstract class CustomFrame : Frame
    {

        protected CustomFrame(Builder builder, IntPtr handle)
            : base(handle)
        {
            Debug.Assert(builder != null);
            builder.Autoconnect(this);

            // extract the frame and remove it from the window
            if (this.Parent is Gtk.Window window)
            {
                window.Remove(this);
                window.Dispose();
            }
            else
                throw new NotSupportedException();
        }

        protected CustomFrame(IntPtr handle)
            : this(builder: null, handle)
        {
            // do nothing
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_disposed)
                {
                    _disposed = true;
                }
            }

            base.Dispose(disposing);
        }

        private bool _disposed = false;
    }
}
