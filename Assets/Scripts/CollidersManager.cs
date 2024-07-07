using System.Collections;
using StarterAssets;
using UnityEngine;

public class CollidersManager : MonoBehaviour
{
    public Box box;
    private Timer timer;
    private CoinSpawner cs;
    public DespawnFloor df1;
    public DespawnFloor df2;
    public GameObject jumpImage;
    public GameObject speedImage;
    public GameObject teleportPosition;
    [SerializeField] private CoinCounter coinsTextCanvas;
    [SerializeField] private DeathAnimation deathAnimation;
    [SerializeField] private FirstPersonController fpsController;
    [SerializeField] private ScenesManager sm;
    [SerializeField] private ScreenFade imgFadeIn;
    [SerializeField] private int lastObjId = 0;
    [SerializeField] private AudioManager audioManager;

    private void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        cs = GameObject.FindGameObjectWithTag("CoinSpawner").GetComponent<CoinSpawner>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        teleportPosition = GameObject.FindGameObjectWithTag("TeleportPosition");
        deathAnimation = GameObject.FindGameObjectWithTag("Player").GetComponent<DeathAnimation>();
        coinsTextCanvas = GameObject.FindGameObjectWithTag("CoinCounter").GetComponent<CoinCounter>();
        imgFadeIn = GameObject.FindGameObjectWithTag("imgFadeIn").GetComponent<ScreenFade>();
        sm = GameObject.FindGameObjectWithTag("ScenesManager").GetComponent<ScenesManager>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //prevent multiple events with the same object collider
        if (lastObjId == hit.gameObject.GetInstanceID()) return;

        switch (hit.gameObject.tag)
        {
            case "Coin":
                Destroy(hit.gameObject);
                if (cs.airCoin) cs.airCoin = false;
                UpdateGameStatus(coinsTextCanvas.points);
                if (cs.gameStarted)
                {
                    timer.increaseTime();
                    coinsTextCanvas.IncreasePoints();
                }
                else
                {
                    cs.gameStarted = true;
                    audioManager.PlayOSTSound();
                };
                lastObjId = hit.gameObject.GetInstanceID();
                audioManager.PlayCoinPickupSound();
                break;

            case "FreezeTime":
                hit.gameObject.SetActive(false);
                audioManager.PlayPowerUpSound();
                StartCoroutine(ActivateFreezeState());
                break;

            case "PowerJump":
                hit.gameObject.SetActive(false);
                audioManager.PlayPowerUpSound();
                StartCoroutine(ActivatePowerJumpState());
                break;

            case "SuperSpeed":
                hit.gameObject.SetActive(false);
                audioManager.PlayPowerUpSound();
                StartCoroutine(ActivatePowerSpeedState());
                break;

            case "Box":
                hit.gameObject.SetActive(false);
                box.spawnPowerUp();
                audioManager.PlayBoxSound();
                break;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Portal":
                fpsController.transform.position = new Vector3(teleportPosition.transform.position.x, teleportPosition.transform.position.y, teleportPosition.transform.position.z);
                Physics.SyncTransforms();
                audioManager.StopFootstepSound();
                audioManager.PlayTeleportSound();
                break;

            case "Lava":
                deathAnimation.PlayerDead(true);
                break;
            case "Yett1":
            case "Yett2":
                deathAnimation.PlayerDead(true);
                break;
        }
    }

    private IEnumerator ActivateFreezeState()
    {
        timer.freezeTime();
        if (timer.freezeImage.activeInHierarchy == false)
        {
            timer.freezeImage.SetActive(true);
        }

        yield return new WaitForSeconds(5f);

        timer.freezeTime();

        if (timer.freezeImage.activeInHierarchy == true)
        {
            timer.freezeImage.SetActive(false);
        }
    }

    private IEnumerator ActivatePowerJumpState()
    {

        fpsController._poweredJump = true;
        fpsController.powerJump();
        if (jumpImage.activeInHierarchy == false)
        {
            jumpImage.SetActive(true);
        }
        yield return new WaitForSeconds(5f);

        fpsController._poweredJump = false;
        fpsController.powerJump();

        if (jumpImage.activeInHierarchy == true)
        {
            jumpImage.SetActive(false);
        }
    }

    private IEnumerator ActivatePowerSpeedState()
    {

        fpsController._poweredSpeed = true;
        fpsController.powerSpeed();
        if (speedImage.activeInHierarchy == false)
        {
            speedImage.SetActive(true);
        }
        yield return new WaitForSeconds(5f);

        fpsController._poweredSpeed = false;
        fpsController.powerSpeed();

        if (speedImage.activeInHierarchy == true)
        {
            speedImage.SetActive(false);
        }
    }


    public IEnumerator ActivateDoors()
    {
        RunAnimation(GameObject.FindGameObjectsWithTag("Yett1"));
        StartCoroutine(ActivateDoorsSound());

        yield return new WaitForSeconds(6f);
        RunAnimation(GameObject.FindGameObjectsWithTag("Yett2"));
    }

    public IEnumerator ActivateDoorsSound()
    {
        audioManager.audioSourceYett1.Play();
        yield return new WaitForSeconds(6f);

        audioManager.audioSourceYett2.Play();
        yield return new WaitForSeconds(6f);

        StartCoroutine(ActivateDoorsSound());
    }

    private void RunAnimation(GameObject[] objs)
    {
        foreach (var gObject in objs)
        {
            gObject.GetComponent<Animator>().enabled = true;
        }
    }

    private void SpawnBox()
    {
        if (box == null)
        {
            GameObject.FindGameObjectWithTag("Box").SetActive(true);
            box = GameObject.FindGameObjectWithTag("Box").GetComponent<Box>();
        }
        box.spawn();
    }

    private void UpdateGameStatus(int points)
    {
        switch (points)
        {
            case 0:
                timer.timerIsRunning = true;
                return;

            case 4:
                df1.Despawn();
                break;

            case 9:
                df2.Despawn();
                break;

            case 14:
                StartCoroutine(ActivateDoors());
                break;

            case 3:
            case 8:
            case 13:
            case 18:
                cs.airCoin = true;
                SpawnBox();
                break;

            case 19:
                imgFadeIn.startFadeIn(sm.LoadWinScene);
                break;
        }
    }

}