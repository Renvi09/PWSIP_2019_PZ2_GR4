using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(LayerMask.GetMask("Interactable"));
    }

    // Update is called once per frame
    void Update()
    {
        MouseTarget();
    }
    private void MouseTarget()
    {
        if(Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity,512);
            if(hit2D.collider !=null && hit2D.collider.tag=="LootBox")
            {
                hit2D.collider.GetComponent<LootBoxScript>().Interact();
            }
        }
    }
   

}
