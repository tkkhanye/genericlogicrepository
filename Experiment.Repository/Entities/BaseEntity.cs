using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiment.Repository.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public bool Active { get; set; } = true;

        public DateTime DateCaptured { get; set; }
        public DateTime DateModified { get; set; }
    }
}
