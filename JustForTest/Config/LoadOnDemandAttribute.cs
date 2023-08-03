using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class LoadOnDemandAttribute : Attribute
{
    // You can add properties or constructors to the attribute if needed.
}
