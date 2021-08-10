using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCompnay.Models
{
    public class EmployeeSkillModel
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int SkillID { get; set; }

        public EmployeeModel Employees { get; set; }
        public SkillModel Skills { get; set; }


    }
    

}
