using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyTeleport : MonoBehaviour
{
    [SerializeField]
    public Vector3 mapStart;
    // Start is called before the first frame update
    private bool isPlayerColison = false;
    private GameObject player;
    public int currentLevel;
 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerColison && Input.GetKeyDown("e"))
        {
            if (GameManager.Instance.maps.Count == 0)
            {

                GameManager.Instance.MakeDungeon();
                SoundManager.Instance.DungeonPlayMusic();
            }
              
                CameraFollow.Instance.SetLimits(mapStart + new Vector3(-12.8f, -7.2f), mapStart - new Vector3(-12.8f, -7.2f));
                player.transform.position = mapStart - new Vector3(10, 0, 0);
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            isPlayerColison = true;

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            isPlayerColison = false;

    }
}