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

    public float maxX, minX;
    public float maxY, minY;

    float newX = 0;
    float newY = 0;

    Vector3[] waypoint = new Vector3[2];

    int current = 0;

    float speed;

    public float slowestSpeed;
    public float fastestSpeed;

    public GameObject red, yellow;

    LineRenderer lr;

    BoxCollider col;

    public Color[] colors;


    void Start()
    {
        environmentPlayer = GameObject.Find("Player Environment");
        waypoint[0] = transform.GetChild(0).position;
        waypoint[1] = transform.GetChild(1).position;
        speed = Random.Range(slowestSpeed, fastestSpeed);
        col = transform.GetChild(3).GetComponent<BoxCollider>();
        lr = GetComponent<LineRenderer>();
    }


    void Update()
    {
        int playerNumber = environmentPlayer.GetComponent<Controller_Movement>().playerNum;

        if (active)
        {
            if(controlled){
                yellow.SetActive(true);
                red.SetActive(false);
            }else{
                yellow.SetActive(false);
                red.SetActive(true);
            }
            
            col.enabled = true;
            lr.enabled = true;

            if (controlled)
            {
                lr.startColor = colors[0];
                lr.endColor = colors[0];
            }
            else {
                lr.startColor = colors[1];
                lr.endColor = colors[1];
            }

        }
        else {
            col.enabled = false;
            lr.enabled = false;
            yellow.SetActive(false);
            red.SetActive(false);
        }

        if (controlled)
        {
            if (playerNumber == 1)
            {
                if (Input.GetButtonDown("X_P1")) {
                    active = !active;
                }

                if (horizontal)
                {
                    newX = 0;

                    newX += (Input.GetAxis("Horizontal_P1") * Time.deltaTime * moveSpeed);

                    if (transform.position.x + newX > minX && transform.position.x + newX < maxX)
                        transform.position = new Vector3(transform.position.x + newX, transform.position.y, transform.position.z);
                }
                else
                {
                    newY = 0;

                    newY += ((Input.GetAxis("Vertical_P1") * Time.deltaTime * moveSpeed));

                    if(transform.position.z + newY > minY && transform.position.z + newY < maxY)
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + newY);
                }
            }
            else
            {
                if (Input.GetButtonDown("X_P2"))
                {
                    active = !active;
                }

                if (horizontal)
                {
                    newX = 0;

                    newX += (Input.GetAxis("Horizontal_P2") * Time.deltaTime * moveSpeed);

                    if (transform.position.x + newX > minX && transform.position.x + newX < maxX)
                        transform.position = new Vector3(transform.position.x + newX, transform.position.y, transform.position.z);
                }
                else
                {
                    newY = 0;

                    newY += ((Input.GetAxis("Vertical_P2") * Time.deltaTime * moveSpeed));

                    if (transform.position.z + newY > minY && transform.position.z + newY < maxY)
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
