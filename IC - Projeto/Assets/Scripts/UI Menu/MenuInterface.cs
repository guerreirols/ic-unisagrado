using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInterface : MonoBehaviour
{
    [SerializeField]
    private Text gameTitleText;

    [SerializeField]
    private Text gameSubtitleText;

    [SerializeField]
    private Text playText;

    [SerializeField]
    private Text tutorialText;

    [SerializeField]
    private Text creditsText;

    [SerializeField]
    private Text exitText;


    void Start()
    {
        gameTitleText.text = Texts.MENU_GAME_TITLE;
        gameSubtitleText.text = Texts.MENU_GAME_SUBTITLE;
        playText.text = Texts.MENU_PLAY;
        tutorialText.text = Texts.MENU_TUTORIAL;
        creditsText.text = Texts.MENU_CREDITS;
        exitText.text = Texts.MENU_EXIT;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(Texts.SCENES_SPACESHIP);
    }
}
