using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyScript : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    public float dmg;
    [SerializeField]
    public int gold;
    [SerializeField]
    private string type;
    [SerializeField]
    private bool isImmortal = false;
    [SerializeField]
    private float speed;
    public string ThisType
    {
        get
        {
            return type;
        }

    }

    public bool IsImmortal
    {
        get
        {
            return isImmortal;
        }

        set
        {
            isImmortal = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }
}
