using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(LayerMask.GetMask("Targetable"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void MouseTarget()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity,256);
            if(hit2D.collider !=null)
            {
                player.target = hit2D.transform.position;
             
            }
        }
    }
   

}
