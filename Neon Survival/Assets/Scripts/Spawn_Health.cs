using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Health : MonoBehaviour
{

    public GameObject health;

    public float timeBetweenPacks;

    void Start()
    {
        InvokeRepeating("SpawnHealth", timeBetweenPacks, timeBetweenPacks);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnHealth(){
        Health_Pack oldPack = GameObject.FindObjectOfType<Health_Pack>();
        if(oldPack != null){
        oldPack.movingToPoint = false;
        oldPack.leaving = true;
        
        Vector2 randomLeave = Random.insideUnitCircle;
        randomLeave.Normalize();
        randomLeave *= 65f;

        oldPack.placeToMove = randomLeave;
        }
        
        
        Vector3 randomSpawn = Random.insideUnitCircle;
        randomSpawn.Normalize();
        randomSpawn *= 40f;

        GameObject newHealth = Instantiate(health, new Vector3(randomSpawn.x, 1, randomSpawn.y), Quaternion.identity);
        Health_Pack pack = newHealth.GetComponent<Health_Pack>();
        pack.placeToMove = new Vector3(Random.Range(-33, 33), 1, Random.Range(-17, 17));
    }
    
}
