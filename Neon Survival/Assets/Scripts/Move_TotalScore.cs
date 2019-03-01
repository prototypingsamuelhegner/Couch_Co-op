using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Move_TotalScore : MonoBehaviour
{
    public GameObject totalScoreObj;

    public float speed;

    public int scoreToDeliver;

    TextMeshProUGUI ui;

    void Start()
    {
        ui = GetComponent<TextMeshProUGUI>();
        totalScoreObj = GameObject.Find("Total Score");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, totalScoreObj.transform.position, Time.deltaTime * speed);

        ui.SetText(scoreToDeliver.ToString());

        if (Vector3.Distance(transform.position, totalScoreObj.transform.position) < 50f) {
            Score_Script.AddToTotal(scoreToDeliver);
            Destroy(gameObject);
        }
    }

    void SetUpJourney() {

    }
}
