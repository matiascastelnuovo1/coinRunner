using Unity.VisualScripting;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip leftFootSound;
    public AudioClip rightFootSound;
    public AudioClip teleportSound;
    public AudioClip pickupBoxSound;
    public AudioClip powerupSound;
    private AudioSource audioSource;
    private AudioSource audioSourceOst;
    private AudioSource audioSourcePowerUp;
    private AudioSource audioSourceCoin;
    private Coroutine footstepCoroutine;
    private bool isLeftFootNext = true;

    public AudioSource audioSourceYett1;
    public AudioSource audioSourceYett2;
    public bool isMoving = false;
    private bool coroutineRunning = false;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        audioSourceOst = GameObject.FindGameObjectWithTag("OST").GetComponent<AudioSource>();
        audioSourcePowerUp = GameObject.FindGameObjectWithTag("PowerUpSound").GetComponent<AudioSource>();
        audioSourceCoin = GameObject.FindGameObjectWithTag("CoinSound").GetComponent<AudioSource>();
        audioSourceYett1 = GameObject.FindGameObjectWithTag("Yett1").GetComponent<AudioSource>();
        audioSourceYett2 = GameObject.FindGameObjectWithTag("Yett2").GetComponent<AudioSource>();
        audioSourceYett1.volume = 0.1f;
        audioSourceYett2.volume = 0.1f;
    }

    private void Update()
    {
        if (isMoving && !coroutineRunning)
        {
            audioSource.volume = 0.01f;
            footstepCoroutine = StartCoroutine(PlayFootstepSound());
            coroutineRunning = true;
        };

        if (!isMoving && coroutineRunning) StopFootstepSound();
    }

    private IEnumerator PlayFootstepSound()
    {
        audioSource.clip = isLeftFootNext ? leftFootSound : rightFootSound;
        audioSource.volume = 0.01f;

        audioSource.Play();
        yield return new WaitForSeconds(0.4f);

        isLeftFootNext = !isLeftFootNext;
        footstepCoroutine = StartCoroutine(PlayFootstepSound());
    }

    public void StopFootstepSound()
    {
        if (footstepCoroutine != null)
        {
            StopCoroutine(footstepCoroutine);
            footstepCoroutine = null;
        }

        audioSource.Stop();
        coroutineRunning = false;
    }

    public void PlayCoinPickupSound()
    {
        audioSourceCoin.Play();
    }

    public void PlayTeleportSound()
    {
        audioSource.clip = teleportSound;
        audioSource.Play();
    }

    public void PlayBoxSound()
    {
        audioSourcePowerUp.clip = pickupBoxSound;
        audioSourcePowerUp.volume = 0.1f;
        audioSourcePowerUp.Play();
    }

    public void PlayOSTSound()
    {
        audioSourceOst.Play();
    }
    public void PlayPowerUpSound()
    {
        audioSourcePowerUp.clip = powerupSound;
        audioSourcePowerUp.volume = 0.1f;
        audioSourcePowerUp.Play();
    }

}