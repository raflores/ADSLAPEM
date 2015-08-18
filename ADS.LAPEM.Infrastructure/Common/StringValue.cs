﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADS.LAPEM.Infrastructure.Common
{
    public class StringValueAttribute : Attribute
    {
        public string StringValue { get; protected set; }

        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }
    }
}
