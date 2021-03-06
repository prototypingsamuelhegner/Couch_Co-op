﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek_Player : MonoBehaviour
{

    GameObject player;

    Rigidbody rb;

    public float speed;
    public float maxSpeed;

    void Awake()
    {
        player = GameObject.Find("Player Ship");
        rb = GetComponent<Rigidbody>();
        maxSpeed = 1;
        InvokeRepeating("RampSpeed", 1.5f, 1.5f);
    }

    

    void Update()
    {
        Vector3 toPlayer = player.transform.position - transform.position;

        toPlayer.Normalize();

        rb.AddForce(toPlayer * speed * Time.deltaTime, ForceMode.VelocityChange);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        if(rb.velocity != Vector3.zero)
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    void RampSpeed() {
        if(gameObject.activeSelf && maxSpeed <= GameObject.Find("Player Ship").GetComponent<Controller_Movement>().maxSpeed)
        maxSpeed += 0.15f;
    }
}
