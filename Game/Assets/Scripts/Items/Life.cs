using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Life", menuName = "Items/Life", order = 7)]
public class Life : Item, IUse,IDescribable
{

    [SerializeField]
    private int life;

    public void Use()
    {
        Remove();
        PlayerStats.Instance.Lifes += life;
    }
    public override string GetDescription()
    {

        return base.GetDescription() + string.Format("\n Gives  + {0} life", life);
    }
}
