using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    //config var's
    [SerializeField] float moveSpeed = 10f;                                                  //changes move speed of player
    [SerializeField] float padding = 1f;                                                     //padding so player doesnt go half off the screen

    float xMin;
    float xMax;

    float yMin;
    float yMax;

    // Use this for initialization
    void Start () {
        SetUpMoveBounderies();

	}

    private void SetUpMoveBounderies()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update () {
        Move();
	}

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;              //added Time.deltaTime to get frame rate independent
        //Debug.Log(deltaX);                                                                //for debuging to see frame rate value in console
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);                // Mathf.Clamp will limit our movement to camera x max and x min
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);

    }


}
