using System.Collections;
using System.Collections.Generic;
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
    PlanetEnter planetEnter;

    void Start()
    {
        audioInput.ChosenPlanet += planetTransition.OnChosenPlanet;
        audioInput.PlayerCommand += audioOutput.OnPlayerCommand;
        audioInput.SaidToComeInPlanet += planetEnter.OnSaidToComeInPlanet;
        audioOutput.ZoeSaid += color.OnZoeSaid;
        planetTransition.WentToThePlanet += spaceshipMovement.OnWentToThePlanet;
        planetEnter.SaidToLand += spaceshipMovement.OnSaidToLand;
    }
}
