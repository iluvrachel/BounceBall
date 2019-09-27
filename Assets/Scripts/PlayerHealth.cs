using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private ParticleSystem ps;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    public static bool isAlive = true;
    private Vector3 finalPos = Vector3.zero;

    public Slider healthBar;

    public AudioSource[] AudioClips = null;

    public AudioSource dieAudio;

    // Start is called before the first frame update
    void Start()
    {
        // rb.gravityScale = 0.5f;
        // gameObject.GetComponent<Controller>().enabled = true;
        // gameObject.GetComponent<TrailRenderer>().enabled = true;
        // gameObject.GetComponent<EnemySpawn>().enabled = true;
        isAlive = true; //THIS IS NECESSARY!!! FK IT..
        ps = gameObject.GetComponent<ParticleSystem>();
        sr = gameObject.GetComponent<SpriteRenderer>(); 
        rb = gameObject.GetComponent<Rigidbody2D>();


        healthBar.value = healthBar.maxValue;
        ps.Stop();
        
        dieAudio = AudioClips[1];
       
    }

    void Awake()
    {

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
        // if (isAlive)
        // {
        //     finalPos = transform.position;
        // }
        // else
        // {
        //     transform.position = finalPos;
        // }

    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag=="Enemy")
        {
            Vector3 up = new Vector3(0f,1f,0f);
            rb.AddForce(up*50f);
            healthBar.value += 15f;   
            CameraRig.isHit = true;

        }
        if(other.gameObject.tag=="Creeper")
        {

            healthBar.value = healthBar.minValue;   
            CameraRig.isHit = true;

        }
        if(other.gameObject.tag=="Purple")
        {
            Vector3 direction = new Vector3(UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f));
            rb.AddForce(direction*UnityEngine.Random.Range(100f,200f));
            CameraRig.isHit = true;

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
        dieAudio.Play();

        //Destroy(gameObject);
    }
}