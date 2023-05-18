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

            if (!currentAudio.isPlaying)
            {
                zoeColorAnimator.SetBool(isTalkingString, false);
                print(zoeColorAnimator);
                hasAudio = false;
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
        if(scene != Texts.SCENES_SPACESHIP)
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