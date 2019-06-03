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
    private string type;

    public string ThisType
    {
        get
        {
            return type;
        }

    }
}
