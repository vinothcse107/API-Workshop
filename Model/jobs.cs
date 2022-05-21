using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Workshop.Model
{
      public class Jobs
      {

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public string Job_ID { get; set; }
            public string Job_Title { get; set; }
            public int Min_Salary { get; set; }
            public int Max_Salary { get; set; }
            public ICollection<employee> Employees { get; set; }

      }
}