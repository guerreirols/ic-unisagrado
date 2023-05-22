using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    [SerializeField]
    AudioInput audioInput;

    [SerializeField]
    PlanetTransition planetTransition;

    [SerializeField]
    AudioOutput audioOutput;

    [SerializeField]
    Color color;

    [SerializeField]
    SpaceshipMovement spaceshipMovement;

    [SerializeField]
    Landing landing;

    [SerializeField]
    Leaving leaving;

    void Start()
    {
        GameObject audioOutputGameObject = GameObject.Find("**AudioOutput Script(Dont Destroy)");
        audioOutput = audioOutputGameObject.GetComponent<AudioOutput>();

        audioInput.PlayerCommand += audioOutput.OnPlayerCommand;
        audioOutput.ZoeSaid += color.OnZoeSaid;

        if (SceneManager.GetActiveScene().name != Texts.SCENES_SPACESHIP)
        {
            audioInput.LeftThePlanet += leaving.OnLeftThePlanet;
        } else {
            audioInput.ChosenPlanet += planetTransition.OnChosenPlanet;
            audioInput.SaidToComeInPlanet += landing.OnSaidToComeInPlanet;
            planetTransition.WentToThePlanet += spaceshipMovement.OnWentToThePlanet;
            landing.SaidToLand += spaceshipMovement.OnSaidToLand;
        }
    }
}