using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Model
{
    internal class PolicyArchiveModel
    {
        public string ID { get; set; }
        public string PolicyName { get; set; }
        public string PolicyType { get; set; }

        public string Desc { get; set; }
        public string CreateDate { get; set; }
    }
}
