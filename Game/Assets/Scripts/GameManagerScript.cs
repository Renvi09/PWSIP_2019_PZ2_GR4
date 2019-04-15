using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public List<GameObject> LevelListNormal;
    public List<GameObject> LevelListBoss;
    public List<Vector3> LevelTeleportList;
    public GameObject player;
    private int LevelSize = 6;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
       MakeDungeon();
    
      
    }
   
    // Update is called once per frame
    void Update()
    {
     
    }
    public void MakeDungeon()
    {
        MakePointList();
        int i = 1;
        List<GameObject> CurrentLevelList = new List<GameObject>();
        for(int j =1;j<=LevelSize;j++)
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
              new Vector3(i*20, 0, 0),
              this.gameObject.transform.rotation);

            room.GetComponentInChildren<TeleportForward>().forward = LevelTeleportList[i - 1] + new Vector3(8, 0, 0);//do zmianny
            room.GetComponentInChildren<TeleportForward>().currentLevel = i;
            room.GetComponentInChildren<TeleportBackward>().backward = LevelTeleportList[i + 1] - new Vector3(8, 0, 0);//do zmianny
            room.GetComponentInChildren<TeleportBackward>().currentLevel = i;
            room.transform.position =(Vector2)LevelTeleportList[i];
            i++;
          
        }



    }
    private void MakePointList()
    {
        LevelTeleportList = new List<Vector3>();
        LevelTeleportList.Add(new Vector3(0, 0, 0));
        for (int i = 0; i <= LevelSize + 1; i++)
        {
            LevelTeleportList.Add(new Vector3(100*i,100,0));
        }
    }
}
