using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    GameObject environmentPlayer;


    public bool active;
    public bool controlled;

    public bool horizontal;

    public float moveSpeed;

    float newX = 0;
    float newY = 0;

    Vector3[] waypoint = new Vector3[2];

    int current = 0;

    float speed;

    public float slowestSpeed;
    public float fastestSpeed;

    // Start is called before the first frame update
    void Start()
    {
        environmentPlayer = GameObject.Find("Player Environment");
        waypoint[0] = transform.GetChild(0).position;
        waypoint[1] = transform.GetChild(1).position;
        speed = Random.Range(slowestSpeed, fastestSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        int playerNumber = environmentPlayer.GetComponent<Controller_Movement>().playerNum;

        if (controlled)
        {
            if (playerNumber == 1)
            {
                if (horizontal)
                {
                    newX += (Input.GetAxis("Horizontal_P1") * Time.deltaTime * moveSpeed);
                    transform.position = new Vector3(transform.position.x + newX, transform.position.y, transform.position.z);
                }
                else
                {
                    newY += ((Input.GetAxis("Vertical_P1") * Time.deltaTime * moveSpeed));
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + newY);
                }
            }
            else
            {
                if (horizontal)
                {
                    newX += (Input.GetAxis("Horizontal_P2") * Time.deltaTime * moveSpeed);
                    transform.position = new Vector3(transform.position.x + newX, transform.position.y, transform.position.z);
                }
                else
                {
                    newY += ((Input.GetAxis("Vertical_P2") * Time.deltaTime * moveSpeed));
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + newY);
                }
            }
        }else{
            float dist = Vector3.Distance(transform.position, waypoint[current]);

            transform.position = Vector3.MoveTowards(transform.position, waypoint[current], Time.deltaTime * speed);

            if (dist < 0.5f)
            {
                speed = Random.Range(slowestSpeed, fastestSpeed);

                if (current == 0)
                {
                    current += 1;
                }
                else
                {
                    current -= 1;
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(active){
            if(controlled){
                if (other.tag == "Player"){
                    SceneManager.LoadScene("Result Screen");
                }
                else if (other.tag == "Enemy")
                {
                    other.gameObject.SetActive(false);
                }
            }
            else{
                if (other.tag == "Player")
                {
                    SceneManager.LoadScene("Result Screen");
                }
            }
        }
    }
}
