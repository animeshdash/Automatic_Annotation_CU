using Automatic_Annotation_CU.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Annotation_CU.Helpers
{
    public static class DrawHelper //: DrawHelperBase
    {
        public static readonly Size ImageSize = new Size(1024, 576);

        private static readonly string[] Colors = new string[] { "#E3330E", "#48E10F", "#D40FE1", "#24ECE3", "#EC2470" };

        public static Color GetColorCode(int index)
        {
            return ColorTranslator.FromHtml(Colors[index % Colors.Length]);
        }
    }
}
