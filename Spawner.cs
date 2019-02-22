using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ship;
    public Transform[] spawnPoint;
    private float NextSpawn = 0f, spawnRate = 0.05f;
    void Awake()
    {
        
    }


    void Update ()
    {
        if(Time.time >= NextSpawn)
        {
            foreach (Transform T in spawnPoint)
            {
                Instantiate(ship, T.transform.position, ship.transform.rotation);
                NextSpawn = Time.time + 100f / spawnRate;

            }
        }
       
	}
    void DecreaseShipCount()
    {

    }
}
