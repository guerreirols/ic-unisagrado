using System.Collections;
using UnityEngine;

public class PlanetTransition : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ultraSpeedParticles;

    [SerializeField]
    private GameObject[] planets;

    [SerializeField]
    private Animator spaceshipShake;

    [SerializeField]
    private Animator zoeShake;

    [SerializeField]
    private int secondsInTransition;

    private Animator currentPlanetAnimator;
    private Animator previousPlanetAnimator;

    private string inTransitionString = "inTransition";

    private string inTransitionSeeingPlanetString = "inTransitionSeeingPlanet";

    public delegate void WentToThePlanetHandler(bool inTransition, GameObject planet);
    public event WentToThePlanetHandler WentToThePlanet;

    public static bool seeingPlanet;

    public static GameObject previousPlanetGameObject;
    public static GameObject currentPlanetGameObject;

    public void Start()
    {
        ultraSpeedParticles.Stop();
    }

    public void OnChosenPlanet(string planet)
    {       
        StartCoroutine(TimeInTransition(planet));
    }

    IEnumerator TimeInTransition(string planet)
    {
        AudioInput.zoeCanTalk = false;

        ultraSpeedParticles.Play();
        SetSpaceshipAndZoeAnimations(true);

        currentPlanetGameObject = GetPlanetGameObjectByTag(planet);
        currentPlanetGameObject.SetActive(true);
        currentPlanetGameObject.GetComponent<MeshRenderer>().enabled = true;

        currentPlanetAnimator = currentPlanetGameObject.GetComponent<Animator>();
        currentPlanetAnimator.SetBool(inTransitionSeeingPlanetString, false);
        currentPlanetAnimator.SetBool(inTransitionString, true);
        WentToThePlanet(true, currentPlanetGameObject);

        if (!seeingPlanet)
        {
            yield return new WaitForSeconds(secondsInTransition);
        }
        else {
            yield return StartCoroutine(TimeInTransitionWhitSeeingPlanet());
        }

        ultraSpeedParticles.Stop();
        SetSpaceshipAndZoeAnimations(false);

        WentToThePlanet(false, null);

        AudioInput.zoeCanTalk = true;
        seeingPlanet = true;
        previousPlanetGameObject = currentPlanetGameObject;
    }

    IEnumerator TimeInTransitionWhitSeeingPlanet()
    {
        previousPlanetAnimator = previousPlanetGameObject.GetComponent<Animator>();
        previousPlanetAnimator.SetBool(inTransitionSeeingPlanetString, true);

        yield return new WaitForSeconds(secondsInTransition);

        previousPlanetGameObject.SetActive(false);
    }

    private void SetSpaceshipAndZoeAnimations(bool condition)
    {
        spaceshipShake.SetBool(inTransitionString, condition);
        zoeShake.SetBool(inTransitionString, condition);
    }

    private GameObject GetPlanetGameObjectByTag(string planet)
    {
        foreach (GameObject planetObject in planets)
        {
            if (planetObject.CompareTag(planet))
            {
                return planetObject;
            }
        }
        return null;
    }
}
