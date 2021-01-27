using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QulixTask.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime employmentDate { get; set; }
        public string position { get; set; }
        public Company company { get; set; }
    }
}
