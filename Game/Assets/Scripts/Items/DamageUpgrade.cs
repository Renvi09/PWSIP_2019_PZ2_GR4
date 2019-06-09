using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DamageUpgrade", menuName = "Items/DmgUpgrade", order = 5)]
public class DamageUpgrade :Item,IUse, IDescribable
{

    [SerializeField]
    private float damage;

    public void Use()
    {
        Remove();
        PlayerStats.Instance.Damage += damage;
    }
    public override string GetDescription()
    {

        return base.GetDescription() + string.Format("\n Damage + {0}", damage);
    }
}
