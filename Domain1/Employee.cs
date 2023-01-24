using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Employee
    {
        [Key]
        public int employeeId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public DateTime birthday { get; set; }
        [ForeignKey("position")]
        public int positionId { get; set; }
        public Position position { get; set; }
        [ForeignKey("credential")]
        public int credentialId { get; set; }
        public Credential credential { get; set; }
    }
}
