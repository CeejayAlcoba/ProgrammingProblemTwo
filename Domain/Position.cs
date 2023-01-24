﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Position
    {
        [Key]
        public int positionId { get; set; }
        public string type { get; set; }
    }
}
