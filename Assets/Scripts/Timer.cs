using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject freezeImage;
    public TextMeshProUGUI text;
    public float timeRemaining;
    public float timeForPowerup;
    [SerializeField] public bool timerIsRunning = false;
    [SerializeField] private DeathAnimation deathAnimation;

    private void Start()
    {
        text.text = "Time Left: 20";
        text = GetComponent<TextMeshProUGUI>();
        deathAnimation = GameObject.FindGameObjectWithTag("Player").GetComponent<DeathAnimation>();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                deathAnimation.PlayerDead();
            }
            text.text = "Time Left: " + ((int)timeRemaining);
        }
    }

    public void increaseTime()
    {
        timeRemaining += 10;
    }

    public void freezeTime()
    {
        timerIsRunning = !timerIsRunning;
    }
}
