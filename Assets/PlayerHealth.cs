﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private ParticleSystem ps;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private bool isAlive = true;
    private Vector3 finalPos = Vector3.zero;

    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        sr = gameObject.GetComponent<SpriteRenderer>(); 
        rb = gameObject.GetComponent<Rigidbody2D>();


        healthBar.value = healthBar.maxValue;
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value -= 0.1f;
        if (Input.GetMouseButtonUp(0))
        {
            healthBar.value -= 5f;
        }

        if (healthBar.value <= 0 && isAlive)
        {
            Die();
            isAlive = false;
        }
        if (isAlive)
        {
            finalPos = transform.position;
        }
        else
        {
            transform.position = finalPos;
        }

    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag=="Enemy")
        {

            healthBar.value += 15f;   

        }
    }

    private void Die()
    {
        sr.enabled = false;
        // stay still
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
        gameObject.GetComponent<Controller>().enabled = false;
        gameObject.GetComponent<TrailRenderer>().enabled = false;
        gameObject.GetComponent<EnemySpawn>().enabled = false;
        //transform.position = finalPos;
        // explode
        ps.Play();

        //Destroy(gameObject);
    }
}