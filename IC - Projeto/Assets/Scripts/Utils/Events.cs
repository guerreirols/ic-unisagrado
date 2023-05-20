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
        switch(SceneManager.GetActiveScene().name)
        {
            case Texts.SCENES_SPACESHIP:
                audioInput.ChosenPlanet += planetTransition.OnChosenPlanet;
                audioInput.PlayerCommand += audioOutput.OnPlayerCommand;
                audioInput.SaidToComeInPlanet += landing.OnSaidToComeInPlanet;
                audioOutput.ZoeSaid += color.OnZoeSaid;
                planetTransition.WentToThePlanet += spaceshipMovement.OnWentToThePlanet;
                landing.SaidToLand += spaceshipMovement.OnSaidToLand;
                break;
            case Texts.SCENES_MARS:
                GameObject audioOutputGameObject = GameObject.Find("**AudioOutput Script(Dont Destroy)");
                GameObject audioInputGameObject = GameObject.Find("**AudioInput Script(Dont Destroy)");
                audioOutput = audioOutputGameObject.GetComponent<AudioOutput>();
                audioInput = audioInputGameObject.GetComponent<AudioInput>();
                audioOutput.ZoeSaid += color.OnZoeSaid;
                audioInput.LeftThePlanet += leaving.OnLeftThePlanet;
                break;
        } 
    }
}