using UnityEngine;

public class UniverseState : MonoBehaviour
{
    [SerializeField]
    private GameObject[] planets;

    [SerializeField]
    private Animator spaceshipAnimator;

    [SerializeField]
    private Animator blackScreenAnimator;

    [SerializeField]
    private GameObject blackScreen;

    private string onLeavingString = "onLeaving";

    void Start()
    {
        if(Leaving.leftPlanet)
        {
            foreach (GameObject planetObject in planets)
            {
                planetObject.SetActive(false);

                if (planetObject.CompareTag(Leaving.currentPlanet))
                {
                    planetObject.SetActive(true);
                }
            }

            spaceshipAnimator.SetBool(onLeavingString, true);
            blackScreen.SetActive(true);
            blackScreenAnimator.SetBool(onLeavingString, true);
            AudioInput.zoeCanTalk = true;
        }
    }
}
