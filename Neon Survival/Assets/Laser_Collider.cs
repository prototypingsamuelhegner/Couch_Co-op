using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser_Collider : MonoBehaviour
{
    bool underControl;
    Laser parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.GetComponent<Laser>();
    }

    // Update is called once per frame
    void Update()
    {
        underControl = parent.controlled;
    }

    void OnTriggerStay(Collider other)
    {
        if (underControl)
        {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene("Result Screen");
            }
            else if (other.tag == "Enemy")
            {
                other.GetComponent<Break_Apart>().Break();

                if (Score_Script.multiplier < 1) {
                    Score_Script.AddMutiplier();
                }
                Score_Script.AddScore(GameObject.Find("Game_Manager").GetComponent<Score_Script>().enemyValue);
            }
        }
        else if(!underControl) {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene("Result Screen");
            }
        }
    }
}
