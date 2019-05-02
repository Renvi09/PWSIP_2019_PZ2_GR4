using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackScript : MonoBehaviour
{
    public float damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<StatHealth>().CurrentValue -= 5;
        }
    }
     
}
