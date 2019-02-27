using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Set_Text : MonoBehaviour
{
    public TextMeshProUGUI score;

    // Update is called once per frame
    void Update()
    {
        score.SetText("Your score was: " + Score_Script.totalScore.ToString());

        if (Input.GetKeyDown(KeyCode.R)) {
            Score_Script.RestartGame();
            SceneManager.LoadScene("Main Scene");
        }
    }
}
