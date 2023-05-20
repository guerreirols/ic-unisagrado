using UnityEngine;

public class UniverseState : MonoBehaviour
{
    [SerializeField]
    private GameObject[] planets;

    private Animator planetAnimator;

    private string isLeavingString = "isLeaving";

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
                    planetAnimator = planetObject.GetComponent<Animator>();

                    planetAnimator.SetBool(isLeavingString, true);
                    planetAnimator.SetBool(isLeavingString, false);
                }
            }
        }
    }
}
