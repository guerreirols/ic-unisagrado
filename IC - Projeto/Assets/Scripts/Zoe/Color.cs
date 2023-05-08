using System.Collections;
using UnityEngine;

public class Color : MonoBehaviour
{
    private static Animator zoeAnimator;
    private static bool hasAudio;

    private static AudioSource currentAudio;

    void Start()
    {
        zoeAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if(hasAudio)
        {
            if (!currentAudio.isPlaying)
            {
                zoeAnimator.SetBool("isTalking", false);
                hasAudio = false;
            }
        }
    }

    public static void IsTalking(AudioSource audio)
    {
        currentAudio = audio;
        hasAudio = true;

        zoeAnimator.SetBool("isTalking", true);
    }

    public void OnZoeSaid(AudioSource currentAudio)
    {
        print(currentAudio);

        while (currentAudio.isPlaying)
        {
            zoeAnimator.SetBool("isTalking", true);
            //hasAudio = false;
        }

        zoeAnimator.SetBool("isTalking", false);
    }
}
