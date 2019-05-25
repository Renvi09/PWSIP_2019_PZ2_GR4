using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

public interface IClicable
{
    Image ThisIcon
    {
        get;
        set;
    }
    int ThisCount
    {
        get;
    }
    Text ThisStackText
    {
        get;
    }


 }
