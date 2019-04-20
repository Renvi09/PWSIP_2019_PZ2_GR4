using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class IntroManager : MonoBehaviour
{
    public float speed = 15;


    void Update()
    {
        Vector3 position = transform.position;

        Vector3 localUp = transform.TransformDirection(0, 1, 0);

        position += localUp * speed * Time.deltaTime;
        transform.position = position;
    }
}
