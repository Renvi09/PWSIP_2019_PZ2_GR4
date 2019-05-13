using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyScript : MonoBehaviour
{
    private float timer=0;
    public Transform target;
    private float timeBetweenBullets=0.5f;

    // Start is called before the first frame update
    void Start()
    {
        target = Player.Instance.transform;
 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Vector2.Distance(transform.position, target.position) < 10)
        {
            if (timer > timeBetweenBullets)
            { 

            timer = 0f;
            var pos = target.position;
            var rotation = Quaternion.FromToRotation(Vector3.up, pos - transform.position);

            var bullet = (GameObject)Instantiate(
                PlayerStats.Instance.SpellList[1],
              transform.position,
                rotation);
            bullet.transform.position = this.transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 5;
            Destroy(bullet, 2.0f);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 3 * Time.deltaTime);
        }
       
    }
}
