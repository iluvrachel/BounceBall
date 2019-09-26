using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creeper : MonoBehaviour
{
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag=="Player")
        {
            //print("hit");
            //explosionAudio.Play();
            //sr.enabled = false;
            //col.enabled = false;
            //ps.Play();
            //Destroy(gameObject,6);
            //ScoreManager.score += 100;
            healthBar.value = healthBar.minValue;

        }
    }
}
