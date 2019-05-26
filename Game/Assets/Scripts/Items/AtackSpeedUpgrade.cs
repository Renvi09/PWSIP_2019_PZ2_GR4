using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AtackSpeedUpgrade", menuName = "Items/AsUpgrade", order = 6)]
 public class AtackSpeedUpgrade : Item, IUse
{

        [SerializeField]
        private float atackSpeed;

        public void Use()
        {
            Remove();
            Player.Instance.TimeBetweenBullets -= atackSpeed;
        }
        public override string GetDescription()
        {

            return base.GetDescription() + string.Format("\n Atack Speed + {0}", atackSpeed*10);
        }
}

