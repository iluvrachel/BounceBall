using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ParticleSystem ps;
    private SpriteRenderer sr;
    private CircleCollider2D col;

    // private bool once = true;
    //private collider
    // Start is called before the first frame update
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        sr = gameObject.GetComponent<SpriteRenderer>(); 
        col =  gameObject.GetComponent<CircleCollider2D>(); 
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player")
        {

            sr.enabled = false;
            col.enabled = false;
            ps.Play();            
            Destroy(gameObject,6);
            ScoreManager.score += 100;
        }
    }
}
