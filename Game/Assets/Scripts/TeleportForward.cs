using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportForward : MonoBehaviour
{
    public Vector3 forward;
    public Vector3 possitons;
    // Start is called before the first frame update
    void Start()
    {
        possitons = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
