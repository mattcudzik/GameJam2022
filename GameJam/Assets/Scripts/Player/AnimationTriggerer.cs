using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationTriggerer : MonoBehaviour
{
    private Animator animator;

    public UnityEvent<string> OnAnimationStart;
    public UnityEvent<string> OnAnimationComplete;

    void Awake()
    {
        animator = GetComponent<Animator>();
        

        for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
        {
            AnimationClip clip = animator.runtimeAnimatorController.animationClips[i];

            AnimationEvent animationStartEvent = new AnimationEvent();
            animationStartEvent.time = 0;
            animationStartEvent.functionName = "AnimationStartHandler";
            animationStartEvent.stringParameter = clip.name;

            AnimationEvent animationEndEvent = new AnimationEvent();
            animationEndEvent.time = clip.length;
            animationEndEvent.functionName = "AnimationCompleteHandler";
            animationEndEvent.stringParameter = clip.name;

            clip.AddEvent(animationStartEvent);
            clip.AddEvent(animationEndEvent);
        }
    }

    public void AnimationStartHandler(string name)
    {
        OnAnimationStart?.Invoke(name);
    }
    public void AnimationCompleteHandler(string name)
    {
        OnAnimationComplete?.Invoke(name);
    }

}
