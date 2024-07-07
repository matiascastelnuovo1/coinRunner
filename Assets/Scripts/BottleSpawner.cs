using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    public GameObject timePrefab;
    public GameObject jumpPrefab;
    public GameObject speedPrefab;

    void Start()
    {
        generateTimeBottle();
        generateJumpBottle();
        generateSpeedBottle();
    }

    void generateTimeBottle()
    {
        Instantiate(timePrefab, new Vector3(-18, 0, 14), Quaternion.identity);
    }
    void generateJumpBottle()
    {
        Instantiate(jumpPrefab, new Vector3(20, 0, 14), Quaternion.identity);
    }
    void generateSpeedBottle()
    {
        Instantiate(speedPrefab, new Vector3(20, 0, 42), Quaternion.identity);
    }
}
