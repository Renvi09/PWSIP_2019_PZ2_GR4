using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UIScripts
{
    interface IUse
    {
        Sprite Icon { get; }
        void Use();
    }
   
}
