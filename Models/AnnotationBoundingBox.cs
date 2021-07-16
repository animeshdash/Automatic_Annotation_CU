using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Annotation_CU.Models
{
    class AnnotationBoundingBox
    {
        public int ObjectIndex { get; set; }
        public float CenterX { get; set; }
        public float CenterY { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public AnnotationBoundingBox() { }

        public AnnotationBoundingBox(AnnotationBoundingBox boundingBox)
        {
            this.ObjectIndex = boundingBox.ObjectIndex;
            this.CenterX = boundingBox.CenterX;
            this.CenterY = boundingBox.CenterY;
            this.Width = boundingBox.Width;
            this.Height = boundingBox.Height;
        }
    }
}
