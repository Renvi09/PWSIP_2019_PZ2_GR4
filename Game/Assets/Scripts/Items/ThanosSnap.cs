using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ThanosSnap", menuName = "Items/ThanosSnap", order = 8)]
public class ThanosSnap : Item,IUse, IDescribable
{ 
  

    public void Use()
    {
        Remove();
        if (Random.Range(0, 99) < 50)
        {
            PlayerStats.Instance.Lifes--;
        }
        else
        {
            for (int i = 0; i < GameManager.Instance.enemyList.Count/2; i++)
            {
                int random = Random.Range(0, GameManager.Instance.enemyList.Count - 1);
                Destroy(GameManager.Instance.enemyList[random]);
                GameManager.Instance.enemyList.Remove(GameManager.Instance.enemyList[random]);
            }
           
        }
    }
    public override string GetDescription()
    {

        return base.GetDescription() + string.Format("\n Wipe half universe ");
    }

}
