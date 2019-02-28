using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public bool lit;

    public float fuseTimer;

    public float explosionActiveTime;

    List<GameObject> thingsHit = new List<GameObject>();

    public GameObject explosion;

    void Start()
    {
        lit = false;
    }

    void Update()
    {
        if (lit) {
            fuseTimer -= Time.deltaTime;
        }

        if (fuseTimer <= 0) {
            Explode();
            fuseTimer = float.MaxValue;
        }
    }

    void Explode() {
        GetComponent<SphereCollider>().enabled = true;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Invoke("DisableBomb", explosionActiveTime);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") {
            SceneManager.LoadScene("Score Screen");
        }

        if (other.tag == "Enemy") {
            if (!thingsHit.Contains(other.gameObject)) {
                other.gameObject.SetActive(false);
                thingsHit.Add(other.gameObject);
                Score_Script.AddMutiplier();
                Score_Script.AddScore(GameObject.Find("Game_Manager").GetComponent<Score_Script>().enemyValue);
            }
        }
    }

    private void DisableBomb()
    {
        GetComponent<SphereCollider>().enabled = false;
        Destroy(gameObject);
    }
}
