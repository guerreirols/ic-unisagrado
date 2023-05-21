using UnityEngine;

public class DisableBlackScreen : StateMachineBehaviour
{

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("Image Black Screen").SetActive(false);
    }
}
