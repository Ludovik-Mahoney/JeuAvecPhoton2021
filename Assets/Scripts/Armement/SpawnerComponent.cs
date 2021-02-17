using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent: MonoBehaviour
{
    public GameObject objectToClone;
    
    [SerializeField]
    private KeyCode spawnKey;

    [SerializeField]
    private Transform spawnPoint;

    void Update()
    {
        if(Input.GetKeyDown(spawnKey))
        {
            Tirer();
        }
    }
    private void Tirer()
    {
         var spawned = Instantiate(objectToClone, spawnPoint.position, transform.rotation);
    }
}
