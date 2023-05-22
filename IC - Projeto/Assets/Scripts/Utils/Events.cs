using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    [Header("Geral Events")]

    [SerializeField]
    AudioInput audioInput;

    [SerializeField]
    AudioOutput audioOutput;

    [SerializeField]
    Color color;

    [Header("Only In a Spaceship")]

    [SerializeField]
    PlanetTransition planetTransition;

    [SerializeField]
    SpaceshipMovement spaceshipMovement;

    [SerializeField]
    Landing landing;

    [Header("Only In a Planet")]

    [SerializeField]
    Leaving leaving;

    void Start()
    {
        //Geral Events
        audioInput.PlayerCommand += audioOutput.OnPlayerCommand;
        audioOutput.ZoeSaid += color.OnZoeSaid;

        if (SceneManager.GetActiveScene().name != Texts.SCENES_SPACESHIP)
        {
            //Only In a Planet
            audioInput.LeftThePlanet += leaving.OnLeftThePlanet;
        } else {
            //Only In a Spaceship
            audioInput.ChosenPlanet += planetTransition.OnChosenPlanet;
            audioInput.SaidToComeInPlanet += landing.OnSaidToComeInPlanet;
            planetTransition.WentToThePlanet += spaceshipMovement.OnWentToThePlanet;
            landing.SaidToLand += spaceshipMovement.OnSaidToLand;
        }
    }
}