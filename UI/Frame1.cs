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

            return new Frame1(builder, builder.GetRawOwnedObject("Frame"));
        }

        protected Frame1(Builder builder, IntPtr handle)
            : base(builder, handle)
        {
            Frame.BorderWidth = 0;
            Frame.ShadowType = ShadowType.None;
        }


#pragma warning disable 649

        [Builder.Object]
        private readonly Frame Frame;

        [Builder.Object]
        private readonly Label FrameLabel;
#pragma warning restore 649

    }

}
