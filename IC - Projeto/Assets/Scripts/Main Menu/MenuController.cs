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
        UnityEngine.XR.XRSettings.enabled = false;
        menuPlay.text = GameTexts.MENU_PLAY;
    }

    public void StartGame()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        } 
        else
        {
            SceneManager.LoadScene(Scenes.SPACESHIP);
        }
    }




}
