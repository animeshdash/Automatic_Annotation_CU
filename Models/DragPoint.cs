using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automatic_Annotation_CU.Models
{
    class DragPoint
    {
        public Point Point { get; private set; }
        public DragPointType Type { get; private set; }
        public Cursor Cursor { get; private set; }
        public double Angle { get; private set; }

        public DragPoint(Point point, DragPointType type, Cursor cursor, double angle)
        {
            this.Point = point;
            this.Type = type;
            this.Cursor = cursor;
            this.Angle = angle;
        }
    }
}
