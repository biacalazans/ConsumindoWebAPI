﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComsumindoWebAPI
{
    public class MyJokes
    {
        public bool error { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string setup { get; set; }
        public string delivery { get; set; }
        public string joke { get; set; }
        public Flags flags { get; set; }
        public int id { get; set; }
        public string lang { get; set; }
    }
}
