using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int points = 0;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (text)
        {

            text.text = "Coins: " + points;
        }
        else
        {
            text = GetComponent<TextMeshProUGUI>();
        }
    }

    public void IncreasePoints()
    {
        points += 1;
    }
}
