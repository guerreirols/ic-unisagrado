using System.Collections;
using UnityEngine;

public class Color : MonoBehaviour
{
    [SerializeField]
    private Animator zoeColorAnimator;

    private AudioSource currentAudio;

    private bool hasAudio;

    private string isTalkingString = "isTalking";

    void Update()
    {
        if(hasAudio)
        {
            if (!currentAudio.isPlaying)
            {
                zoeColorAnimator.SetBool(isTalkingString, false);
                hasAudio = false;
            }
        }
    }

    public void OnZoeSaid(AudioSource currentAudio)
    {
        this.currentAudio = currentAudio;
        zoeColorAnimator.SetBool(isTalkingString, true);
        hasAudio = true;  
    }
}