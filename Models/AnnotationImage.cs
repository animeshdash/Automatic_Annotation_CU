using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Annotation_CU.Models
{
    class AnnotationImage
    {
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public List<AnnotationBoundingBox> BoundingBoxes { get; set; }
        //public AnnotationPackage Package { get; set; }
    }
}
