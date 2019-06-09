using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBossScript : EnemyScript
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] spells;
    float timer;
    private int stage=1;
    float timerStage;
    public int Stage
    {
        get
        {
            return stage;
        }

        set
        {
            stage = value;
        }
    }

    void Start()
    {

        target = Player.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<StatHealth>().CurrentValue< GetComponent<StatHealth>().maxValue/2)
        {
           stage = 2;
        }

        timer += Time.deltaTime;
        if(stage==2)
        {
            timerStage += Time.deltaTime;
        }
    
        if (Stage >0 && timer > 4f)
        {
            timer = 0f;
            var pos = Player.Instance.transform.position;
            var rotation = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
           
            var bullet = (GameObject)Instantiate(
              spells[Random.Range(0,spells.Length-1)],
              transform.position,
                rotation);
            bullet.transform.position = this.transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 5;
            bullet.GetComponent<EnemyAtack>().damage = 5 + dmg;
            bullet.GetComponent<EnemyAtack>().wawe =0;

            Destroy(bullet, 2.0f);
        }
        if(Stage == 2 && timerStage>15)
        {
            timerStage = 0f;
            GameManager.Instance.RespawnEnemy(this.transform);
        }
    }
}
