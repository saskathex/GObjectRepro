using System;
using Gtk;
using System.Reflection;

namespace GObjectRepro.UI
{
    class Frame2 : CustomFrame
    {
        public static Frame2 Create()
        {
            var fullname = MethodBase.GetCurrentMethod().DeclaringType.FullName;
            var builder = new Builder(null, fullname + ".glade", null);

            return new Frame2(builder, builder.GetRawOwnedObject("Frame"));
        }

        protected Frame2(Builder builder, IntPtr handle)
            : base(builder, handle)
        {
            // do nothing
        }
    }

}
