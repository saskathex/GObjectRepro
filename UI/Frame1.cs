using System;
using Gtk;
using System.Reflection;

namespace GObjectRepro.UI
{
    class Frame1 : CustomFrame
    {
        public static Frame1 Create()
        {
            var fullname = MethodBase.GetCurrentMethod().DeclaringType.FullName;
            var builder = new Builder(null, fullname + ".glade", null);

            return new Frame1(builder, builder.GetObject("Frame").Handle);
        }

        protected Frame1(Builder builder, IntPtr handle)
            : base(builder, handle)
        {
            // do nothing
        }
    }

}
