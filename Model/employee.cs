using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Workshop.Model
{
      public class employee
      {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]

            public int EmployeeID { get; set; }
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public string Email { get; set; }
            public string Phone_Number { get; set; }

            public DateTime Hire_Date { get; set; }


            [ForeignKey("Jobs")]
            public string Job_Id { get; set; }
            [JsonIgnore]
            public Jobs Jobs { get; set; }

            public float salary { get; set; }
            public float Commission_PCT { get; set; }
            public int Manager_ID { get; set; }


            [ForeignKey("Department")]
            public int Department_ID { get; set; }
            [JsonIgnore]
            public department Department { get; set; }

      }

}
