using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    private Vector3 offset;
    public GameObject player;
    private Vector3 targetPos;
    private Vector3 moveSpeed; 
    private float dampTime = 0.1f;

    private float defaultZoom = 7;
    private float zoomSpeed = 0.2f;
    private float velZoom;
    private float yMin = 0;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // camera follow
        targetPos = player.transform.position + offset; 
        transform.position  = Vector3.SmoothDamp (transform.position, targetPos, ref moveSpeed, dampTime); //player.transform.position + offset;    


        // camera zoom
        float desiredZoom = defaultZoom + Vector3.Distance(transform.position,player.transform.position);
        if(desiredZoom>18)
        {
            desiredZoom = 18;
        }
        Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, desiredZoom, ref velZoom, zoomSpeed);

        if(transform.position.y < yMin)
        {
            transform.position = new Vector3(transform.position.x,yMin,transform.position.z);
        }
    }
}
