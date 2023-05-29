using System.Collections;
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

    [SerializeField]
    private GameObject[] planets;

    [SerializeField]
    private Animator cameraAnimator;

    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private GameObject tutorial;

    [SerializeField]
    private GameObject credits;

    [SerializeField]
    private GameObject blackScreen;

    [SerializeField]
    private GameObject goBackButton;


    void Start()
    {
        planets[Random.Range(0, 6)].SetActive(true);

        gameTitleText.text = Texts.MENU_GAME_TITLE;
        gameSubtitleText.text = Texts.MENU_GAME_SUBTITLE;
        playText.text = Texts.MENU_PLAY;
        tutorialText.text = Texts.MENU_TUTORIAL;
        creditsText.text = Texts.MENU_CREDITS;
        exitText.text = Texts.MENU_EXIT;
    }

    public void StartGame()
    {
        StartCoroutine(StartGameTransition());
    }

    public void Tutorial()
    {
        cameraAnimator.SetBool("optionSelected", true);
        menu.SetActive(false);
        tutorial.SetActive(true);
        goBackButton.SetActive(true);
    }

    public void Credits()
    {
        cameraAnimator.SetBool("optionSelected", true);
        menu.SetActive(false);
        credits.SetActive(true);
        goBackButton.SetActive(true);
    }

    public void Back()
    {
        cameraAnimator.SetBool("optionSelected", false);
        credits.SetActive(false);
        tutorial.SetActive(false);
        menu.SetActive(true);
        goBackButton.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator StartGameTransition()
    {
        blackScreen.SetActive(true);

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(Texts.SCENES_SPACESHIP);
    }
}
