using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class LoadOnDemandAttribute : Attribute
{
    public string Name { get; }
    public LoadOnDemandAttribute(string name)
    {

        Name = name;
    }
}
