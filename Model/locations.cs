using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Workshop.Model
{
      public class Location
      {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Location_Id { get; set; }
            public ICollection<department> Department { get; set; }

            public string Street_Address { get; set; }
            public string Postal_Code { get; set; }
            public string City { get; set; }
            public string State_Province { get; set; }

      }

}