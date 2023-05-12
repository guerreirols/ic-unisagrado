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

    private string inTransitionString = "inTransition";

    public delegate void WentToThePlanetHandler(bool inTransition, GameObject planet);
    public event WentToThePlanetHandler WentToThePlanet;


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
        ultraSpeedParticles.Play();
        SetAnimations(true);
        ActivePlanet(planet);

        yield return new WaitForSeconds(secondsInTransition);

        ultraSpeedParticles.Stop();
        SetAnimations(false);

        WentToThePlanet(false, null);
    }

    private void SetAnimations(bool condition)
    {
        spaceshipShake.SetBool(inTransitionString, condition);
        zoeShake.SetBool(inTransitionString, condition);
    }

    private void ActivePlanet(string planet)
    {
        foreach (GameObject planetObject in planets)
        {
            planetObject.SetActive(false);

            if (planetObject.CompareTag(planet))
            {
                planetObject.SetActive(true);
                WentToThePlanet(true, planetObject);
            }
        }
    }
}
