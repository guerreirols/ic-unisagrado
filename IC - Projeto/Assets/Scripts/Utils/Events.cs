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

    void Start()
    {
        audioInput.ChosenPlanet += planetTransition.OnChosenPlanet;
        audioInput.PlayerCommand += audioOutput.OnPlayerCommand;
        audioOutput.ZoeSaid += color.OnZoeSaid;
    }
}
