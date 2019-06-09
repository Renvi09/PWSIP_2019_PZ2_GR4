using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBossScript : EnemyScript
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] spells;
    bool spawned=false;
    float timer;
    float enrageTimer;
    float spawnTimer=15f;
    float atackSpeed = 4f;
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
        Debug.Log(spawned);
        target = Player.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        enrageTimer += Time.deltaTime;
        if(enrageTimer>120)
        {
            atackSpeed = 0.4f;
        }
        if(stage >1 && stage < 3 && GetComponent<StatHealth>().CurrentValue < GetComponent<StatHealth>().maxValue / 5)
        {
            stage = 3;

        }
        if (stage <2 &&  GetComponent<StatHealth>().CurrentValue< GetComponent<StatHealth>().maxValue/2)
        {
           
           stage = 2;
           timerStage = 15f;
        }

        timer += Time.deltaTime;
        if(stage>1)
        {
            timerStage += Time.deltaTime;
        }
    
        if (Stage >0 && timer > atackSpeed)
        {
            timer = 0f;
            var pos = Player.Instance.transform.position;
            var rotation = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
           
            var bullet = (GameObject)Instantiate(
              spells[0],
              transform.position,
                rotation);
            bullet.transform.position = this.transform.position;
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 5;
            bullet.GetComponent<EnemyAtack>().damage = 5 + dmg;
            bullet.GetComponent<EnemyAtack>().wawe =0;

            Destroy(bullet, 2.0f);
        }
        if(stage > 1 && timerStage>spawnTimer &&!spawned)
        {
            timerStage = 0f;
            GameManager.Instance.RespawnEnemy(this.transform);
        }
        if(stage==3 && !spawned)
        {
            spawned = true;
            var clone = (GameObject)Instantiate(
            this.gameObject,
            transform.position + new Vector3(-5,0),
            transform.rotation);
            clone.GetComponent<MageBossScript>().spawned = true;
            clone.GetComponent<StatHealth>().maxValue = GetComponent<StatHealth>().maxValue;
            clone.GetComponent<StatHealth>().CurrentValue = GetComponent<StatHealth>().CurrentValue;
            GameManager.Instance.enemyList.Add(clone);
           
            var clone2 = (GameObject)Instantiate(
            this.gameObject,
            transform.position + new Vector3(5,0),
            transform.rotation);

            clone2.GetComponent<MageBossScript>().spawned = true;
            clone2.GetComponent<StatHealth>().maxValue = GetComponent<StatHealth>().maxValue;
            clone2.GetComponent<StatHealth>().CurrentValue = GetComponent<StatHealth>().CurrentValue;

            GameManager.Instance.enemyList.Add(clone2);
         
            var clone3 = (GameObject)Instantiate(
            this.gameObject,
            transform.position + new Vector3(0,5),
            transform.rotation);

            clone3.GetComponent<MageBossScript>().spawned = true;
            clone3.GetComponent<StatHealth>().maxValue = GetComponent<StatHealth>().maxValue;
            clone3.GetComponent<StatHealth>().CurrentValue = GetComponent<StatHealth>().CurrentValue;

            GameManager.Instance.enemyList.Add(clone3);
        
            var clone4 = (GameObject)Instantiate(
            this.gameObject,
            transform.position + new Vector3(0,-5),
            transform.rotation);

            clone4.GetComponent<MageBossScript>().spawned = true;
            clone4.GetComponent<StatHealth>().maxValue = GetComponent<StatHealth>().maxValue;
            clone4.GetComponent<StatHealth>().CurrentValue = GetComponent<StatHealth>().CurrentValue;

            GameManager.Instance.enemyList.Add(clone4);


        }
    }
}
