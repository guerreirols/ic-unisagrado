using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Text menuPlay;

    void Start()
    {
        menuPlay.text = Texts.MENU_PLAY;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(Texts.SCENES_SPACESHIP);
    }
}
