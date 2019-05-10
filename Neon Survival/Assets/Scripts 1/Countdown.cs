using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    IEnumerator CountdownTimer()
    {
        yield return new WaitForSeconds(18);
        SceneManager.LoadScene(2);
    }
}