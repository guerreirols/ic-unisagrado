using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialScreen : StateMachineBehaviour
{

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("Start Canvas").SetActive(false);
    }
}
