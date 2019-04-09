using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public List<GameObject> LevelList;
    private GameObject tempMap;
    // Start is called before the first frame update
    void Start()
    {
       MakeDungeon();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MakeDungeon()
    {
        int i = 1;
        foreach(GameObject map in LevelList)
        {
            var map2 = (GameObject)Instantiate(
              map,
              new Vector3(i*20, 0, 0),
              this.gameObject.transform.rotation);
            tempMap = map2;
            map2.GetComponentInChildren<TeleportForward>().forward = i;
            map2.GetComponentInChildren<TeleportBackward>().backward = i - 1;
            tempMap.transform.position =new Vector2( tempMap.transform.position.x + 10,0);
            i++;
        }
    }

}
