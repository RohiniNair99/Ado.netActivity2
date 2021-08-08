using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityDTO
{
    public class GraderDTO
    {
        public int BCFId { get; set; }
        public int PSNO { get; set; }
        public double Score { get; set; }
        public int GId { get; set; }

        public string CourseId { get; set; }
    }
}
