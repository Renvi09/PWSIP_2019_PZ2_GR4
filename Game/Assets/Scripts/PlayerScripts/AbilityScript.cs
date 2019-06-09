using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScript : MonoBehaviour
{
    private float damage;

    public float Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<StatHealth>().CurrentValue -= Damage;
        }
        if (collision.gameObject.tag == "Boss" && !collision.gameObject.GetComponent<EnemyScript>().IsImmortal)
        {
            collision.gameObject.GetComponent<StatHealth>().CurrentValue -= Damage;
        }
    }
}
