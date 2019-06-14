using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "HammerStorm", menuName = "Items/HammerStrom", order = 10)]
public class HammerStorm : Item,IUse,IDescribable
{
    [SerializeField]
    private float damage=1;
    [SerializeField]
    private GameObject hammer;
    public void Use()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Remove();
            for (int i = 0; i < 4; i++)
            {
             
          
                var obHamer = (GameObject)Instantiate(
                    hammer,
                  Player.Instance.transform.position,
                  Player.Instance.transform.rotation);
                obHamer.GetComponent<AbilityScript>().Damage = damage * 0.1f*PlayerStats.Instance.Damage;

                obHamer.GetComponent<CircleStrike>().Angle = i * 1.5f;
                Destroy(obHamer, 10f);

            }
        }

    }
    public override string GetDescription()
    {

        return base.GetDescription() + string.Format("\n Spins hammers around you!\n Deals {0} damage.", damage * 0.1f * PlayerStats.Instance.Damage);
    }
}
