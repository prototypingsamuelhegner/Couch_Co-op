using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Bomb : MonoBehaviour
{
    public GameObject[]bombs;

    Vector2 minCam;
    Vector2 maxCam;

    Camera cam;

    public int ammountOfBombs;

    public float timeBetweenBombs;

    public List<GameObject> activeBombs = new List<GameObject>();    
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        minCam = cam.ScreenToWorldPoint(Vector3.zero);
        maxCam = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, 0));
        InvokeRepeating("SpawnBomb", timeBetweenBombs, timeBetweenBombs);
    }

    void SpawnBomb(){
        if(activeBombs.Count < ammountOfBombs){
            int ranBomb = 0;
            float ran = Random.Range(0, 100);

            if(ran >= 0 && ran <= 45){
                ranBomb = 0;
            }else if(ran > 45 && ran <= 80){
                ranBomb = 1;
            }else if(ran > 80 && ran <= 100){
                ranBomb = 2;
            }

            GameObject newBomb = Instantiate(bombs[ranBomb], new Vector3(Random.Range(-33, 33), 1, Random.Range(-17, 17)), Quaternion.identity, transform);
            activeBombs.Add(newBomb);
        }
    }
}
