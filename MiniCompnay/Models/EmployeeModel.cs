using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCompnay.Models
{
    public class EmployeeModel
    {
        public int ID { get; set;}
        [MaxLength(1000)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Email { get; set; }

        public ICollection<EmployeeSkillModel> EmployeeSkills { get; set; }

    }
}
