using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Manager : MonoBehaviour
{
    public GameObject[] lasers;

    public float timePerLaser;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ActivateLaser", timePerLaser, timePerLaser);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateLaser() {
        bool selected = false;
        while (!selected) {

            int count = 0;

            foreach (GameObject game in lasers) {
                if (game.GetComponent<Laser>().active || game.GetComponent<Laser>().controlled) {
                    count++;
                }
            }

            if (count == 4) {
                selected = true;
                break;
            }

            int ran = Random.Range(0, 4);


            if (!lasers[ran].GetComponent<Laser>().active)
            {
                lasers[ran].GetComponent<Laser>().active = true;
                selected = true;
            }
        }
        

        
    }
}
