using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class Credential
    {
        [Key]
        public int credentialId { get; set; }
        public string username { get; set; }

        [NotMapped]
        public string password { get; set; }
        [JsonIgnore]
        public byte[] salted { get; set; }
        [JsonIgnore]
        public string hashed { get; set; }
    }
}
