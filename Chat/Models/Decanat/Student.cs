﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models.Decanat {
    internal class Student {

        public string? Name { get; set; }

        public string? SurName { get; set; }

        public string? Patronymic { get; set;}

        public DateTime? Birthday { get; set; }

        public double? Rating { get; set; }
    }
}
