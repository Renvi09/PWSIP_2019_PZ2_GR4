using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TeleportBackward : MonoBehaviour
{

    public Vector3 backward;
    private bool isPlayerColison = false;
    private GameObject player;
    public int currentLevel;
    public Text currentLevelText;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");
      currentLevelText = GameObject.FindGameObjectWithTag("LevelText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerColison && Input.GetKeyDown("e"))
        {
            currentLevelText.text = (currentLevel - 1).ToString();
            if (currentLevel == 6)
            {
                CameraFollow.Instance.SetLimits(backward + new Vector3(-25f, -14f), backward - new Vector3(-25f, -14f));
                player.transform.position = backward + new Vector3(20, 0, 0);

            }
            else
            {

                CameraFollow.Instance.SetLimits(backward + new Vector3(-12.8f, -7.2f), backward - new Vector3(-12.8f, -7.2f));
                player.transform.position = backward + new Vector3(10, 0, 0);

            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag=="Player")
           isPlayerColison = true;
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            isPlayerColison = false;
     
    }
} 
  
   


