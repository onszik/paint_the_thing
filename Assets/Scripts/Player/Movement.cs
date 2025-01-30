using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    
    private Vector3 mousePos;
    public float moveSpeed = 0.5f;
    public float moveCoef = 1.5f;

    private Vector3 playerPos;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        float xPos;
        float yPos;

        Vector3 move;

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerPos = transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            move = cam.ScreenToWorldPoint(Input.mousePosition) - mousePos;
            transform.position = playerPos + move * moveCoef;

            xPos = Mathf.Clamp(transform.position.x, -cam.orthographicSize * cam.GetComponent<Camera>().aspect, cam.orthographicSize * cam.GetComponent<Camera>().aspect);
            yPos = Mathf.Clamp(transform.position.y, -cam.orthographicSize, cam.orthographicSize);

            transform.position = new Vector3(xPos, yPos, 0);
        }
    }

    private void OnEnable()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos = transform.position;
    }
}

