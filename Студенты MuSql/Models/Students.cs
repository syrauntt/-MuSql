using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Студенты_MuSql.Models
{
    internal class Students
    {
        public int Stu_id { get; set; }
        public string Stu_Name { get; set;}
        public string Stu_SurName { get; set;}  
        public int Stu_Age { get; set;} 
        public int Stu_AvgScore { get; set;}
    }
}
