using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLeavingScene : StateMachineBehaviour
{
    public float keyframeTime = 0.30f;

    private GameObject planetGameObject;

    private MeshRenderer[] saturnMeshRenders;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        planetGameObject = PlanetTransition.previousPlanetGameObject;

        float normalizedTime = stateInfo.normalizedTime;

        if (normalizedTime >= keyframeTime)
        {
            if(planetGameObject.tag != Texts.EVENTS_SATURN)
            {
                planetGameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                saturnMeshRenders = planetGameObject.GetComponentsInChildren<MeshRenderer>();

                foreach (MeshRenderer meshRenderer in saturnMeshRenders)
                {
                    meshRenderer.enabled = false;
                }
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        planetGameObject = PlanetTransition.previousPlanetGameObject;

        planetGameObject.GetComponent<Animator>().SetBool("inTransitionSeeingPlanet", false);
        planetGameObject.GetComponent<Animator>().SetBool("inTransition", true);
        planetGameObject.SetActive(false);
    }
}
