using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementSpeedUpgrade", menuName = "Items/MsUpgrade", order = 4)]
public class MovementSpeedUpgrade : Item,IUse, IDescribable
{
    [SerializeField]
    private float movementSpeed;

    public void Use()
    {
        Remove();
        PlayerStats.Instance.MovementSpeed+= movementSpeed;
    }
    public override string GetDescription()
    {

        return base.GetDescription() + string.Format("\n Movemnt speed + {0}", movementSpeed*10);
    }


}
