using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private GameObject gm;
    private GameObject player;


    //private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        gm = transform.Find("GameOver").gameObject;
        gm.SetActive(false);

        player = GameObject.FindWithTag("Player");

        //dieAudio = GetComponent<AudioSource> ();
        
    }


    // Update is called once per frame
    void Update()
    {
        if (!PlayerHealth.isAlive && gm.activeSelf==false)
        {
            gm.SetActive(true);
            //PlayerHealth.isAlive = true;
            //dieAudio.Play();
        }
    }

}
