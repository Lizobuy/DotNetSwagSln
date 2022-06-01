﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetSwag.Models
{
    public class Orders
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}
