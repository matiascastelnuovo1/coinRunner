using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DeathAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private ScenesManager sm;
    [SerializeField] private ScreenFade imgFadeIn;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        sm = GameObject.FindGameObjectWithTag("ScenesManager").GetComponent<ScenesManager>();
        imgFadeIn = GameObject.FindGameObjectWithTag("imgFadeIn").GetComponent<ScreenFade>();
    }

    public void PlayerDead(bool withAnimation = false)
    {
        GetComponent<CharacterController>().enabled = false;
        GetComponent<FirstPersonController>().enabled = false;

        if (withAnimation)
        {
            GetComponentInChildren<Animator>().enabled = true;
            StartCoroutine(WaitForAnimation(animator));
            return;
        }

        imgFadeIn.startFadeIn(sm.LoadDeathScene);

    }

    private IEnumerator WaitForAnimation(Animator animator)
    {
        do
        { yield return null; }
        while (
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f
            );

        imgFadeIn.startFadeIn(sm.LoadDeathScene);
    }
}
