using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaving : MonoBehaviour
{
    [SerializeField]
    private Animator screenAnimator;

    public static bool leftPlanet;

    public static string currentPlanet;

    public void OnLeftThePlanet(string planet)
    {
        AudioInput.zoeCanTalk = false;
        screenAnimator.SetBool("isLeaving", true);
        leftPlanet = true;
        currentPlanet = planet;
    }
}
