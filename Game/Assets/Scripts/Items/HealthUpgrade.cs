using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HealthUpgrade", menuName = "Items/HpUpgrade", order = 3)]
public class HealthUpgrade : Item,IUse
{
    [SerializeField]
    private float health;

    public void Use()
    {
        Remove();
        PlayerStats.Instance.MaxHealth += health;
    }
    public override string GetDescription()
    {

        return base.GetDescription() + string.Format("\n Max health + {0}", health);
    }

}
