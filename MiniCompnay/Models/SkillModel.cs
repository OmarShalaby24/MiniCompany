using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCompnay.Models
{
    public class SkillModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeSkillModel> EmployeeSkills { get; set; }
    }
}
