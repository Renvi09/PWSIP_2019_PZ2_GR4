using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TeleportForward : MonoBehaviour
{
    public Vector3 forward;
    // Start is called before the first frame update
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
        if (isPlayerColison && Input.GetKeyDown("e"))
        {
            player.transform.position = forward;
            currentLevelText.text = (currentLevel - 1).ToString();
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
