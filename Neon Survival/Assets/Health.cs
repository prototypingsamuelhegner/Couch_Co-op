using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    int health;

    public int startHealth;

    void Start()
    {
        health = startHealth;
    }

    void Update()
    {
        if (health <= 0) {
            SceneManager.LoadScene("Result Screen");
        }
    }

    public void AddHealth(int healthToAdd)
    {
        health += healthToAdd;
    }

    public void RemoveHealth(int healthToRemove)
    {
        health -= healthToRemove;
    }
}
