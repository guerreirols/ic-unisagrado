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

    public delegate void SaidToLandHandler(bool onLand);
    public event SaidToLandHandler SaidToLand;

    public void OnSaidToComeInPlanet(int idPlanet)
    {
        StartCoroutine(TimeInLanding(idPlanet));
    }

    IEnumerator TimeInLanding(int idPlanet)
    {
        SaidToLand(true);
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
        switch (idPlanet)
        {
            case 1:
                //mercury
                break;
            case 2:
                //venus
                break;
            case 3:
                //earth
                break;
            case 4:
                SceneManager.LoadScene(Texts.SCENES_MARS);
                break;
            case 5:
                //jupiter
                break;
            case 6:
                //saturn
                break;
            case 7:
                //uranus
                break;
            case 8:
                //neptune
                break;
        }
    }
}
