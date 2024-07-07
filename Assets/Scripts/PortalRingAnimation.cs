using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortalRingAnimation : MonoBehaviour
{
    public GameObject cFloor;
    private string[] sides = new[] { "front", "right", "back", "left" };
    private string currentSide;
    private int speed = 15;

    void Start()
    {
        currentSide = sides[0];
        cFloor = GameObject.FindGameObjectWithTag("CentralFloor");
    }

    void Update()
    {
        if (cFloor == null)
        {
            cFloor = GameObject.FindGameObjectWithTag("CentralFloor");
        }

        if (currentSide == sides[0] && transform.position.x < 25)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            return;
        }
        currentSide = sides[1];

        if (currentSide == sides[1] && transform.position.z < 50 && transform.position.x > -28.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
            return;
        }
        currentSide = sides[2];

        if (currentSide == sides[2] && transform.position.x > -28.5f)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            return;
        }
        currentSide = sides[3];

        if (currentSide == sides[3] && transform.position.z > 6)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
            return;
        }
        currentSide = sides[0];
    }
}