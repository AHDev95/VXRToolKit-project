using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    GameObject[] selectSpawns;
    [SerializeField]
    GameObject objectPreFab ;

    // Start is called before the first frame update
    void Start()
    {
        selectSpawns = GameObject.FindGameObjectsWithTag("staticSpawn");
        foreach (GameObject spawn in selectSpawns)
        {
            GameObject spawnObj = Instantiate(objectPreFab, spawn.transform, false);

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
