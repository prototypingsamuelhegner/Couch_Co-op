using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_Script : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Score Screen");
        }

        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.SetActive(false);
            Score_Script.AddMutiplier();
            Score_Script.AddScore(GameObject.Find("Game_Manager").GetComponent<Score_Script>().enemyValue);
        }
    }
}
