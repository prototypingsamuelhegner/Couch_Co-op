using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Manager : MonoBehaviour
{
    public GameObject[] lasers;

    public GameObject flash;

    public float timePerLaser;

    int ran;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChooseLaser", timePerLaser, timePerLaser);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChooseLaser() {
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

            ran = Random.Range(0, 4);


            if (!lasers[ran].GetComponent<Laser>().active)
            {
                Invoke("StartLaser", 5f);
                Instantiate(flash, lasers[ran].transform.position, Quaternion.identity, lasers[ran].transform);
                selected = true;
            }
        }
    }

    void StartLaser(){
        lasers[ran].GetComponent<Laser>().active = true;
    }
}
