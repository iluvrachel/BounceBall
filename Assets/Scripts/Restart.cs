using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class Restart : MonoBehaviour
{

    //public AudioSource restartAudio;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(RestartScene);
        //restartAudio = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartScene()
    {
        //restartAudio.Play();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
