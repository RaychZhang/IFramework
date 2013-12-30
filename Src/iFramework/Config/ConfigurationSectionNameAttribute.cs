﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFramework.Config
{
    public class ConfigurationSectionNameAttribute : Attribute
    {
        public ConfigurationSectionNameAttribute(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
