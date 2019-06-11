using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "SunStrike", menuName = "Items/SunStrike", order = 9)]
public class SunStrike : Item,IUse, IDescribable
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private GameObject sunStrike;
    public void Use()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            Remove();
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition,Camera.MonoOrStereoscopicEye.Mono);
            pos = new Vector3(pos.x, pos.y, Player.Instance.transform.position.z);
           
            var rotation = Quaternion.FromToRotation(Vector3.up, Player.Instance.transform.position - pos);
            var bullet = (GameObject)Instantiate(
                sunStrike,
              pos,
              rotation);
            bullet.GetComponent<AbilityScript>().Damage = damage;
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 8;
            Destroy(bullet, 4.0f);
        }

    }
    public override string GetDescription()
    {

        return base.GetDescription() + string.Format("\n Your enemies will burn!\n Deals {0}", damage);
    }
}
