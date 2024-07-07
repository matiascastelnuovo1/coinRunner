using System;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public bool airCoin = false;
    public bool gameStarted = false;
    private int lastPos;
    Vector3[] spawnPositions;

    void Start()
    {
        spawnPositions = new[] {
            new Vector3(1, 0.5f, 41 ),
            new Vector3(-12, 0.5f, 28),
            new Vector3(14, 0.5f, 28),
            new Vector3(17, 12.5f, 28 ),
            new Vector3(-15, 12.5f, 28 ),
            new Vector3(1, 12.5f, 16 ),
            new Vector3(1, 12.5f, 40 ),
            new Vector3(1, 22, 28 ),
            };
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Coin").Length == 0 && gameStarted)
        {
            generateCoin();
        }
    }

    void generateCoin()
    {
        int pos;

        if (airCoin)
        {
            pos = 7;
        }
        else
        {
            System.Random rnd = new System.Random();
            pos = rnd.Next(7);
            while (pos == lastPos)
            {
                pos = rnd.Next(7);
            }
            lastPos = pos;
        }
        Instantiate(coinPrefab, spawnPositions[pos], Quaternion.identity);
    }
}
