﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Models
{
    public class ChangeStatusRequest
    {
        public string Id { get; set; }
        public string Status { get; set; }
    }
}
