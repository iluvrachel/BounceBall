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

    public static bool isHit = false;
    private float shakeTime = 0.1f;
    private Vector3 originalPos;
    private float shakeAmount = 0.2f;
    private float decreaseFactor = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        isHit = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // camera follow
        targetPos = player.transform.position + offset; 
            

        if (isHit)
        {
            if (shakeTime > 0)
            {
                transform.position = originalPos + Random.insideUnitSphere * shakeAmount;

                shakeTime -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeTime = 0f;
                transform.position = originalPos;
                isHit = false;
                shakeTime = 0.1f;
            }
        }
        else
        {
            transform.position  = Vector3.SmoothDamp (transform.position, targetPos, ref moveSpeed, dampTime); //player.transform.position + offset;
            originalPos = transform.position;
        }


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
