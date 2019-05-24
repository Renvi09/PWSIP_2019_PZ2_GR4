using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
 
    private static CameraFollow instance;
    public static CameraFollow Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<CameraFollow>();
            }
            return instance;
        }


    }
    private Vector2 velocity;
    public float smothY;
    public float smothX;
    GameObject player;
    private float xMax, xMin, yMax, yMin;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetLimits(new Vector3(-12.8f,-7.2f), new Vector3(12.8f, 7.2f));
    }


    private void LateUpdate()
    {
         float poX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smothX);
         float poY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smothY);
         transform.position = new Vector3(poX, poY, transform.position.z);
     //transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, xMin,xMax), Mathf.Clamp(player.transform.position.y, yMin,yMax),-10);
    }
    public void SetLimits(Vector3 min, Vector3 max)
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        xMin = min.x + width / 2;
        xMax = max.x - width / 2;
        yMin = min.y + height / 2;
        yMax = max.y - height / 2;
        
    }
}



