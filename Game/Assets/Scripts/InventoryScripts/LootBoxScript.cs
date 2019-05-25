using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxScript : MonoBehaviour,IInteractable
{
    [SerializeField]
    private LootTable lootTable;
    // Start is called before the first frame update
    private void Awake()
    {
        lootTable = GetComponent<LootTable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void Interact()
    {
        lootTable.ShowLoot();
        
    }

    public void StopInteract()
    {
        LootWindowScript.Instance.Close();
    }
}
