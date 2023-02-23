using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    private Vector3 dragOrigin;
    private float zoomValue = 0.5f;
    private float minCamSize = 1.5f;
    private float maxCamSize = 7;
    private float leftBorderCoordinate = -12;
    private float topBorderCoordinate = 4;
    private float rightBorderCoordinate = 9;
    private float bottomBorderCoordinate = -5;
    private bool secretEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveCam();
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            ZoomIn();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            ZoomOut();
        }
    }
    private void moveCam()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0) && !secretEnabled)
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 camPos = cam.transform.position;
            camPos += difference;
            if (camPos.x < leftBorderCoordinate)
            {
                camPos.x = leftBorderCoordinate;
            }
            if (camPos.x > rightBorderCoordinate)
            {
                camPos.x = rightBorderCoordinate;
            }
            if (camPos.y < bottomBorderCoordinate)
            {
                camPos.y = bottomBorderCoordinate;
            }
            if (camPos.y > topBorderCoordinate)
            {
                camPos.y = topBorderCoordinate;
            }
            cam.transform.position = camPos;
        }
    }
    private void ZoomIn()
    {
        float newSize = cam.orthographicSize + zoomValue;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }
    private void ZoomOut()
    {
        float newSize = cam.orthographicSize - zoomValue;
        cam.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }

    public void enableSecret()
    {
        secretEnabled = true;
    }

    public void disableSecret()
    {
        secretEnabled = false;
    }
}
