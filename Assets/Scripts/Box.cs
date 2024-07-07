using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject FreezeTime;
    public GameObject SuperSpeed;
    public GameObject PowerJump;

    void Update()
    {
        if (FreezeTime == null)
        {
            FreezeTime = GameObject.FindGameObjectWithTag("FreezeTime").GetComponent<GameObject>();
        }
        if (SuperSpeed == null)
        {
            SuperSpeed = GameObject.FindGameObjectWithTag("SuperSpeed").GetComponent<GameObject>();
        }
        if (PowerJump == null)
        {
            PowerJump = GameObject.FindGameObjectWithTag("PowerJump").GetComponent<GameObject>();
        }

    }
    public void spawn()
    {
        gameObject.SetActive(true);
    }

    public void spawnPowerUp()
    {
        System.Random rnd = new System.Random();
        int pos = rnd.Next(1, 4);

        switch (pos)
        {
            case 1:
                FreezeTime.SetActive(true);
                break;
            case 2:
                PowerJump.SetActive(true);
                break;
            case 3:
                SuperSpeed.SetActive(true);
                break;
        }
    }
}
