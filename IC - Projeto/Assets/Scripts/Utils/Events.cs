using UnityEngine;

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

    void Start()
    {
        audioInput.ChosenPlanet += planetTransition.OnChosenPlanet;
        audioInput.PlayerCommand += audioOutput.OnPlayerCommand;
        audioInput.SaidToComeInPlanet += landing.OnSaidToComeInPlanet;
        audioOutput.ZoeSaid += color.OnZoeSaid;
        planetTransition.WentToThePlanet += spaceshipMovement.OnWentToThePlanet;
        landing.SaidToLand += spaceshipMovement.OnSaidToLand;
    }
}
