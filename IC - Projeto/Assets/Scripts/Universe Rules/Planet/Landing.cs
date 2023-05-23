using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Landing : MonoBehaviour
{
    [SerializeField]
    private Animator spaceshipAnimator;

    [SerializeField]
    private Animator zoeAnimator;

    [SerializeField]
    private Animator directionalLightAnimator;

    [SerializeField]
    private int secondsOnLanding;

    [SerializeField]
    private GameObject[] planets;

    public delegate void SaidToLandHandler(bool onLand, GameObject planet);
    public event SaidToLandHandler SaidToLand;

    public void OnSaidToComeInPlanet(int idPlanet)
    {
        StartCoroutine(TimeInLanding(idPlanet));
    }

    IEnumerator TimeInLanding(int idPlanet)
    {
        AudioInput.zoeCanTalk = false;

        SaidToLand(true, GetPlanetGameObjectByTag(GlobalProperties.planetTag));
        SetAnimation(1);
        StartCoroutine(DisablePlanet());

        yield return new WaitForSeconds(secondsOnLanding);

        changeScene(idPlanet);
    }

    IEnumerator DisablePlanet()
    {
        yield return new WaitForSeconds(2);

        SetAnimation(2);

        foreach (GameObject planetObject in planets)
        {
            planetObject.SetActive(false);
        }
    }

    private void SetAnimation(int stage)
    {
        string onLandingString = "onLanding";

        if(stage == 1)
        {
            spaceshipAnimator.SetBool(onLandingString, true);
            zoeAnimator.SetBool(onLandingString, true);
        }
        else if(stage == 2)
        {
            directionalLightAnimator.SetBool(onLandingString, true);
        }
    }

    private void changeScene(int idPlanet)
    {
        PlanetTransition.seeingPlanet = false;
        AudioInput.zoeCanTalk = true;

        switch (idPlanet)
        {
            case 1:
                SceneManager.LoadScene(Texts.SCENES_MERCURY);
                break;
            case 2:
                SceneManager.LoadScene(Texts.SCENES_VENUS);
                break;
            case 4:
                SceneManager.LoadScene(Texts.SCENES_MARS);
                break;
        }
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
