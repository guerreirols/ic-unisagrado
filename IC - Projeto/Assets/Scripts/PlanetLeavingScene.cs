using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLeavingScene : StateMachineBehaviour
{
    public float keyframeTime = 0.30f;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float normalizedTime = stateInfo.normalizedTime;

        if (normalizedTime >= keyframeTime)
        {
            PlanetTransition.previousPlanetGameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlanetTransition.previousPlanetGameObject.GetComponent<Animator>().SetBool("inTransitionSeeingPlanet", false);
        PlanetTransition.previousPlanetGameObject.GetComponent<Animator>().SetBool("inTransition", true);
        PlanetTransition.previousPlanetGameObject.SetActive(false);
    }
}
