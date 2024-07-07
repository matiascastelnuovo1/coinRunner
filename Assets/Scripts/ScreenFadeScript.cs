using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ScreenFade : MonoBehaviour
{
    public Image blackScreen;
    public Image tutorialScreen;
    public float fadeSpeed = 1f;

    [SerializeField] private ScenesManager sm;

    public delegate void DelegatedScene();
    private void Start()
    {
        sm = GameObject.FindGameObjectWithTag("ScenesManager").GetComponent<ScenesManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            hideTutorial();
        }
    }

    public void hideTutorial()
    {
        StartCoroutine(HideTutorialImg());
    }

    public void startFadeIn(DelegatedScene sceneFn)
    {
        StartCoroutine(FadeToBlackAndLoadScene(sceneFn));
    }

    IEnumerator HideTutorialImg()
    {
        RectTransform rectTransform = tutorialScreen.GetComponent<RectTransform>();
        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 endPosition = new Vector2(startPosition.x, Screen.height + rectTransform.sizeDelta.y);

        float elapsedTime = 0f;
        while (elapsedTime < fadeSpeed)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, elapsedTime / fadeSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        tutorialScreen.gameObject.SetActive(false);
    }

    IEnumerator FadeToBlackAndLoadScene(DelegatedScene sceneFn)
    {
        Color color = blackScreen.color;
        while (color.a < 1f)
        {
            color.a += fadeSpeed * Time.deltaTime;
            blackScreen.color = color;
            yield return null;
        }

        sceneFn();
    }
}