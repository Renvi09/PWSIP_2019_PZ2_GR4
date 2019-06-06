using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public delegate void KillConfirmed(EnemyScript enemy);
public class GameManager : MonoBehaviour
{
    public List<GameObject> maps = new List<GameObject>();
    public event KillConfirmed KillConfirmedEvent;
    private static GameManager instance;
    [SerializeField]
    private Shop upgrades;
    [SerializeField]
    private Shop basicShop;
    [SerializeField]
    private QuestGiver questGiver;
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private List<GameObject> loot;
    [SerializeField]
    private List<GameObject> lootBoxes;
    private int dayCount = 1;
    [SerializeField]
    private List<Quest> questList;
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

    public int DayCount
    {
        get
        {
            return dayCount;
        }

        set
        {
        
            DayUp();         
            dayCount = value;
        }
    }

    void Update()
    {
        MouseTarget();
        if (Input.GetKeyDown(KeyCode.P))
        {
            DayCount++;
        }
    }
    private void MouseTarget()
    {
        if(Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity,512);
            if(hit2D.collider !=null)
            {
                if(hit2D.collider.tag == "LootBox" || hit2D.collider.tag=="NPC")
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
        MakePointList();
    }

    public void MakeDungeon()
    {
       
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
            maps.Add(room);
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
                        enemies[Random.Range(0, enemies.Count)],
                       center.position - new Vector3(Random.Range(-12f,0f), Random.Range(-7f, 7f)),
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
         var go = Instantiate(lootBoxes[Random.Range(0, lootBoxes.Count - 1)],center.position,transform.rotation);
        loot.Add(go);
    }
    public void ClearEnemies()
    {
        
        foreach(GameObject ob in enemyList)
        {
           
            Destroy(ob);
        }
        enemyList.Clear();
    }
    public void ClearMaps()
    {
     
        foreach (GameObject ob in maps)
        {
            Destroy(ob);
        }
        maps.Clear();
    }
    public void ClearBoxes()
    {

        foreach (GameObject ob in loot)
        {
            Destroy(ob);
        }
        loot.Clear();
    }
    public void OnKillConfirmed(EnemyScript enemy)
    {
        if(KillConfirmedEvent !=null)
        {
            KillConfirmedEvent(enemy);
        }
    }
    public void DayUp()
    {
        if (questList.Count > 2)
        {
            questGiver.Quests.Add(questList[0]);
            questGiver.Quests.Add(questList[1]);
            questGiver.Quests.Add(questList[2]);
            questList.Remove(questList[2]);
            questList.Remove(questList[1]);
            questList.Remove(questList[0]);

        }
        ClearMaps();
        ClearEnemies();
        ClearBoxes();
    }
}
