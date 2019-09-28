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

    public static bool hitSign = false;
    
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

        hitSign = false;
        //releaseSign = 0;
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
        // if(Controller.releaseSign==0)
        // {
        //     Combo.comboCount = 0;
        //     //hitSign = false;
        // }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag=="Player")
        {

            hitSign = true;
            Combo.comboCount += 1;
            Controller.releaseSign = 0;
            //print("hit");
            explosionAudio.Play();
            sr.enabled = false;
            col.enabled = false;
            ps.Play();
            Destroy(gameObject,6);
            ScoreManager.score += Combo.comboCount*100;



 

            //Combo.comboCount += 1;
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
