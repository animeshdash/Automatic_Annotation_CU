using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Annotation_CU.Helpers
{
    class TaskJsonResult
    {
        public int taskId { get; set; }
        public string fileName { get; set; }
        public string taskLevel { get; set; }
        public string priority { get; set; }

        public DateTime dtCreated { get; set; }
        public string status { get; set; }

        internal static DataTable DeserializeObject(object jsonString, Type type)
        {
            throw new NotImplementedException();
        }
    }
}
