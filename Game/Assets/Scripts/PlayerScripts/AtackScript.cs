using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<StatHealth>().CurrentValue -= PlayerStats.Instance.Damage;
        }
        if (collision.gameObject.tag == "Boss" && !collision.gameObject.GetComponent<EnemyScript>().IsImmortal)
        {
            collision.gameObject.GetComponent<StatHealth>().CurrentValue -= PlayerStats.Instance.Damage;
        }
    }
     
}
