using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value -= 0.1f;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag=="Enemy")
        {

            healthBar.value += 10f;   

        }
    }
}