using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class Bomb : MonoBehaviour
{
    public bool lit;

    public float fuseTimer;

    float maxFuse;

    public float explosionActiveTime;

    public GameObject range;
    public GameObject model;

    List<GameObject> thingsHit = new List<GameObject>();

    public GameObject explosion;


    

    Vector3 ogScale;

    void Start()
    {
        lit = false;
        maxFuse = fuseTimer;
        ogScale = range.transform.localScale;
    }

    void Update()
    {
        if (lit) {
            fuseTimer -= Time.deltaTime;
            range.transform.localScale -= ogScale / (1/Time.deltaTime) * (1/maxFuse);
            Color col = new Color(1f, 0.1f, 1f);
            range.GetComponent<Renderer>().material.SetColor("Color_61CF4ABE", col);
        }else{
            Color col = new Color(1f, 1f, 1f, 0f);
            range.GetComponent<Renderer>().material.SetColor("Color_61CF4ABE", col);
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
        CameraShaker.Instance.ShakeOnce(10f, 10f, 0.1f, 1f);
        GetComponent<AudioSource>().Play();
        transform.parent.GetComponent<Spawn_Bomb>().activeBombs.Remove(this.gameObject);
        range.SetActive(false);
        model.SetActive(false);
        Invoke("DestroyBomb", 1.5f);
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
    }

    void DestroyBomb() {
        Destroy(gameObject);
    }
}
