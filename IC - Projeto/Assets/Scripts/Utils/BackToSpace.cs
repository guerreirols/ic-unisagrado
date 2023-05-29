using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToSpace : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneManager.LoadScene(Texts.SCENES_SPACESHIP);
    }
}
