﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4;

interface INameAndCopy
{
    string Name { get; set; }
    object DeepCopy();
}