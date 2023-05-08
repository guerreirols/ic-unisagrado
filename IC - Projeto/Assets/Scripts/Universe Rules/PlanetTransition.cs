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

    public static bool inTransition = false;


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
        inTransition = true;

        ultraSpeedParticles.Play();
        SetAnimations(true);
        ActivePlanet(planet);

        yield return new WaitForSeconds(secondsInTransition);

        ultraSpeedParticles.Stop();
        SetAnimations(false);

        inTransition = false;
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
            }
        }
    }
}
