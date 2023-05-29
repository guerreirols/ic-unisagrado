using UnityEngine;
using UnityEngine.SceneManagement;

public class Color : MonoBehaviour
{
    [SerializeField]
    private Animator zoeColorAnimator;

    [SerializeField]
    private Animator zoeBodyAnimator;

    [SerializeField]
    private Transform zoeTransform;

    [SerializeField]
    private Transform playerTransform;

    private AudioSource currentAudio;

    private bool hasAudio;

    private string isTalkingString = "isTalking";

    private string scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if(hasAudio)
        {
            zoeColorAnimator.SetBool(isTalkingString, true);
            AudioInput.zoeCanTalk = false;

            if (!currentAudio.isPlaying)
            {
                zoeColorAnimator.SetBool(isTalkingString, false);
                hasAudio = false;
                AudioInput.zoeCanTalk = true;
            }
        }

        if(AudioInput.zoeIsListening)
        {
            SetZoeBodyAnimation(true);
        }
        else
        {
            SetZoeBodyAnimation(false);
        }
    }

    private void SetZoeBodyAnimation(bool status)
    {
        if(scene == Texts.SCENES_MERCURY || scene == Texts.SCENES_VENUS || scene == Texts.SCENES_MARS)
        {
            this.zoeBodyAnimator.SetBool(isTalkingString, status);
        }     
    }

    public void OnZoeSaid(AudioSource currentAudio)
    {
        this.currentAudio = currentAudio;
        hasAudio = true;  
    }
}