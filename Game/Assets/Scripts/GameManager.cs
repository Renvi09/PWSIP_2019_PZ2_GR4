using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    //zwraca  instancje
    public static GameManager Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

            }
            return instance;
        }


    }
    void Update()
    {
        MouseTarget();
    }
    private void MouseTarget()
    {
        if(Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity,512);
            if(hit2D.collider !=null)
            {
                if(hit2D.collider.tag == "LootBox")
                {
                    hit2D.collider.GetComponent<LootBoxScript>().Interact();
                }
                else if(hit2D.collider.tag == "Vendor")
                {

                }
              
            }
        }
    }

    public List<GameObject> LevelListNormal;
    public List<GameObject> LevelListBoss;
    public List<Vector3> LevelTeleportList;
    private int LevelSize = 6;
    // Start is called before the first frame update
    void Start()
    {
        MakeDungeon();
    }

    public void MakeDungeon()
    {
        MakePointList();
        int i = 1;
        List<GameObject> CurrentLevelList = new List<GameObject>();
        for (int j = 1; j <= LevelSize; j++)
        {
            int newLevel = Random.Range(0, LevelListNormal.Count);
            CurrentLevelList.Add(LevelListNormal[newLevel]);

        }
        int newLevelBoss = Random.Range(0, LevelListBoss.Count);
        CurrentLevelList.Add(LevelListBoss[newLevelBoss]);
        foreach (GameObject map in CurrentLevelList)
        {

            var room = (GameObject)Instantiate(
              map,
              new Vector3(i * 20, 0, 0),
              this.gameObject.transform.rotation);

            room.GetComponentInChildren<TeleportBackward>().backward = LevelTeleportList[i - 1];
            room.GetComponentInChildren<TeleportBackward>().currentLevel = i;
            room.GetComponentInChildren<TeleportForward>().forward = LevelTeleportList[i + 1];
            room.GetComponentInChildren<TeleportForward>().currentLevel = i;
            room.transform.position = (Vector2)LevelTeleportList[i];
            i++;

        }



    }
    private void MakePointList()
    {
        LevelTeleportList = new List<Vector3>();
        LevelTeleportList.Add(new Vector3(-8, 0, 0));
        for (int i = 0; i <= LevelSize; i++)
        {
            LevelTeleportList.Add(new Vector3(100 * i, 100, 0));
        }
        LevelTeleportList.Add(new Vector3(0, 0, 0));
    }
}
