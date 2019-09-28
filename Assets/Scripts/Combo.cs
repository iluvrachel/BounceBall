using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour
{
    public static int comboCount;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent <Text> ();
        comboCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Combo X" + comboCount;
    }
}
