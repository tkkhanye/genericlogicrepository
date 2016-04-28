using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiment.Models.DomainModels
{
    public class BaseModel
    {
        public int ID { get; set; }
        public bool Active { get; set; }
        //public DateTime DateCaptured { get; set; }
        //public DateTime DateModified { get; set; }
        
    }
}
