using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxScript : MonoBehaviour
{
    [SerializeField]
    private LootTable lootTable;
    // Start is called before the first frame update
    private void Awake()
    {
        lootTable = GetComponent<LootTable>();
    }
    void Start()
    {
        Debug.Log(LayerMask.GetMask("Interactable"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void Interact()
    {
        lootTable.ShowLoot();
        
    }
}
