using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Script : MonoBehaviour
{
    public static int totalScore;

    public static int score;

    public int enemyValue;

    public static int multiplier;

    public static float timeTillDecrease = 4f;

    public static float multTimer;

    public TextMeshProUGUI _mult;
    public TextMeshProUGUI _score;
    public TextMeshProUGUI _totalScore;


    public GameObject tempText;
    static GameObject seekText;

    public static Vector3 spawnPoint;

    void Start()
    {
        spawnPoint = _score.transform.position;
        seekText = tempText;
        multTimer = timeTillDecrease;
    }

    void Update()
    {
        if (multiplier > 1) {
            multTimer -= Time.deltaTime;
        }
        

        if (multTimer <= 0) {
            RestartTimer();

            multiplier = 1;
            multTimer = timeTillDecrease;
        }

        SetText();
    }

    public void SetText() {
        _mult.SetText(multiplier + "x");
        _score.SetText(score.ToString());
        _totalScore.SetText(totalScore.ToString());
    }

    public static void AddMutiplier() {
        multiplier++;
        multTimer = timeTillDecrease;
    }

    public static void AddScore(int enemyValue) {
        score += enemyValue;
    }

    public static void RestartGame() {
        totalScore = 0;
        score = 0;
        multiplier = 1;
        multTimer = timeTillDecrease;
    }

    public static void RestartTimer() {
        multTimer = timeTillDecrease;

        GameObject _temp = Instantiate(seekText, spawnPoint, Quaternion.identity, GameObject.Find("Canvas").transform);
        
        _temp.GetComponent<Move_TotalScore>().scoreToDeliver = (score * multiplier);

        score = 0;
        multiplier = 1;
    }

    public static void AddToTotal(int toAdd) {
        totalScore += toAdd;
    }

}
