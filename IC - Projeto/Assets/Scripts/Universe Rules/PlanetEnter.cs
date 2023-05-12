using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetEnter : MonoBehaviour
{
    [SerializeField]
    private Animator spaceshipAnimator;

    [SerializeField]
    private int secondsOnLanding;

    public delegate void SaidToLandHandler(bool onLand);
    public event SaidToLandHandler SaidToLand;

    public void OnSaidToComeInPlanet(int idPlanet)
    {
        StartCoroutine(TimeInLanding(idPlanet));
    }

    IEnumerator TimeInLanding(int idPlanet)
    {
        SaidToLand(true);

        yield return new WaitForSeconds(secondsOnLanding);

        changeScene(idPlanet);
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
