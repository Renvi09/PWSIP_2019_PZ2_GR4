﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosRoom : MonoBehaviour
{
    private bool drop = false;
    private int droped = 0;
    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (drop)
        {

            if (droped < 1 && !GameManager.Instance.isEnemy())
            {
                drop = false;
                droped = 1;
                GameManager.Instance.DropBossLoot(this.transform);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!spawned && collision.tag == "Player")
        {
            spawned = true;
            GameManager.Instance.SpawnBoss(this.transform);
            drop = true;
        }


    }
}
