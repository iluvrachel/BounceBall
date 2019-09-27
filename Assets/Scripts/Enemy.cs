using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ParticleSystem ps;
    private SpriteRenderer sr;
    private CircleCollider2D col;

    public AudioSource explosionAudio;

    private bool isVis = true;
    private int timer = 0;
    // private bool once = true;
    //private collider
    // Start is called before the first frame update
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        sr = gameObject.GetComponent<SpriteRenderer>(); 
        col =  gameObject.GetComponent<CircleCollider2D>(); 
        ps.Stop();

        explosionAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isVis)
        {
            timer++;
            //print(timer);
        }
        else
        {
            timer = 0;
        }
        if(timer==300)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag=="Player")
        {
            //print("hit");
            explosionAudio.Play();
            sr.enabled = false;
            col.enabled = false;
            ps.Play();
            Destroy(gameObject,6);
            ScoreManager.score += 100;
        }
    }

    private void OnBecameVisible() 
    {
        isVis = true;
    }

    private void OnBecameInvisible() 
    {
        isVis = false;
    } 

}
