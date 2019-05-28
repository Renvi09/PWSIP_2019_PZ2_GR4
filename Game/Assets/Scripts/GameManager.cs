using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private List<GameObject> lootBoxes;
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
                    Player.Instance.Interact();
                }
              
            }
        }
    }

    public List<GameObject> LevelListNormal;
    public List<GameObject> LevelListBoss;
    public List<Vector3> LevelTeleportList;
    private int LevelSize = 6;
    public List<GameObject> enemyList= new List<GameObject>();

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
        LevelTeleportList.Add(new Vector3(0, 0, 0));
        for (int i = 0; i <= LevelSize; i++)
        {
            LevelTeleportList.Add(new Vector3(100 * i, 100, 0));
        }
        LevelTeleportList.Add(new Vector3(0, 0, 0));
    }
    public void RespawnEnemy(Transform center)
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < enemies.Count; j++)
            {
               GameObject enemy= Instantiate(
                        enemies[Random.Range(0,3)],
                       center.position - new Vector3(Random.Range(-8f, 12f), Random.Range(-7f, 7f)),
                       transform.rotation


                        );
                enemyList.Add(enemy);
            }
        }
    
    }
    public  bool isEnemy()
   {
        if (enemyList.Count ==0)
        {
            return false;
        }
        else
        return true;
    }
    public void DropLoot(Transform center)
    {
        Instantiate(lootBoxes[Random.Range(0, lootBoxes.Count - 1)],center.position,transform.rotation);
    }
    public void ClearEnemies()
    {
        
        foreach(GameObject ob in enemyList)
        {
            enemyList.Remove(ob);
            Destroy(ob);
        }
    }
}
