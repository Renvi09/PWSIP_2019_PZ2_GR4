using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 velocity;
    public float smothY;
    public float smothX;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        float poX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smothX);
        float poY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smothY);
        transform.position = new Vector3(poX, poY, transform.position.z);
    }
}



