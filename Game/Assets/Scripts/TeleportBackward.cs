using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBackward : MonoBehaviour
{
    public Vector3 backward;
    private bool isPlayerColison = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerColison && Input.GetKeyDown("e"))
        {
            player.transform.position = backward;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerColison = true;
        Debug.Log(isPlayerColison);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerColison = false;
        Debug.Log(isPlayerColison);
    }
} 
  
   


