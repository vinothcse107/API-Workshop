using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_Workshop.Model
{


      public class department
      {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Department_ID { get; set; }
            public string Department_Name { get; set; }
            public int Manager_ID { get; set; }


            [ForeignKey("Location")]
            public int Location_ID { get; set; }
            [JsonIgnore]
            public Location Location { get; set; }


            public ICollection<employee> Employees { get; set; }

      }

}