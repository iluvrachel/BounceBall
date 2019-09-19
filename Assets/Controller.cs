using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Controller : MonoBehaviour
{
    private bool isMouseDown = false;
    private Vector3 lastMousePosition = Vector3.zero; // Mouse up position
    private Vector3 MousePosition = Vector3.zero; // Current mouse position
    private Vector3 rb_Position = Vector3.zero;
    private Rigidbody2D rb;
    private double clickpoint_dis = 0.0; // Mouse down position
    private CircleCollider2D circle;

    //public GameObject m_prefab; 
    //private GameObject parent;
    //private GameObject child;

    public Slider aim; // Aim slider
    private double curForce  = 0.0; // Force that add to the ball
    private Vector3 drag_dis; //Distance between mouse and rb

    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); //Rigidbody of Player
        circle = gameObject.GetComponent<CircleCollider2D>(); // Collider of Player
        //parent = transform.gameObject; // 
    }

    // Update is called once per frame
    void Update()
    {
        OnClick();
    }

    /**
     * @description: Mouse click listener, to control the Player ball movement
     * @param {type} 
     * @return: 
     */
    private void OnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Vector3.zero;
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb_Position = rb.position;
            // distance between clickpoint and rigidbody
            clickpoint_dis = Math.Pow((MousePosition.x-rb_Position.x),2)+Math.Pow((MousePosition.y-rb_Position.y),2);
            if(clickpoint_dis < Math.Pow(circle.radius*rb.transform.localScale.x,2)) // click inside the ball
            {
                lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Time.timeScale = 0.1f; //slow motion
                Time.fixedDeltaTime = 0.02F*Time.timeScale; // frame smooth
                
                isMouseDown = true;
                //Create();
            }
            
        }

        if(isMouseDown)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            drag_dis = target - rb_Position;
            // calculate the value of aim slider
            curForce = (Math.Pow(drag_dis.x,2)+Math.Pow(drag_dis.y,2))*10;
            aim.value = (float)curForce;

            //Change the sprite's rotation
            Vector3 v = target - transform.position;
            v.z = 0;
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, v);
            transform.rotation = rotation;
        }

        if (Input.GetMouseButtonUp(0))
        {
            //release
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02F*Time.timeScale; 
            aim.value = 0;
            if (lastMousePosition != Vector3.zero && isMouseDown)
            {
                // push the ball with a force according to drag distance
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition)- rb_Position;
                rb.AddForce(offset*Time.deltaTime*10000.0f); 
                isMouseDown = false;
                
                //transform.position += offset;
            }
            //lastMousePosition = Vector3.zero;
        }
    }


    // private void Create()
    // {
    //     child = GameObject.Instantiate(m_prefab,transform.position,Quaternion.identity);
    //     child.transform.parent = transform;
    // }
}
