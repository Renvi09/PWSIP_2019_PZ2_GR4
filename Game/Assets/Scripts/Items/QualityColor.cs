using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum Quality { Common, Uncommon, Rare, Epic }
public static class QualityColor
{
    private static Dictionary<Quality, string> colors = new Dictionary<Quality, string>()
    {
        {Quality.Common  ,"#C0C0C0"},
        {Quality.Uncommon  ,"#00FF00"},
        {Quality.Rare  ,"#FFFF00"},
        {Quality.Epic  ,"#FF6600"},

    };

    public static Dictionary<Quality, string> ThisColors
    {
        get
        {
            return colors;
        }
    }
}