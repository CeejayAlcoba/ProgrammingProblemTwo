using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Position
    {
        [Key]
        public int positionId { get; set; }
        public string type { get; set; }

    }
}
