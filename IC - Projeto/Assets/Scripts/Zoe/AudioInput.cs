using UnityEngine;
using KKSpeech;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioInput : MonoBehaviour
{
    public static bool zoeIsListening;

    private int idPlanet;

    private int idLastPlanet;

    private string currentPlanet;

    public delegate void ChosenPlanetHandler(string msg);
    public event ChosenPlanetHandler ChosenPlanet;

    public delegate void SaidToComeInPlanetHandler(int idPlanet);
    public event SaidToComeInPlanetHandler SaidToComeInPlanet;

    public delegate void PlayerCommandHandler(int idCommand);
    public event PlayerCommandHandler PlayerCommand;

    public delegate void LeftThePlanetHandler(string planet);
    public event LeftThePlanetHandler LeftThePlanet;


    public static bool zoeCanTalk = true;

    private string voiceResult;

    void Start()
    {
        if (SpeechRecognizer.ExistsOnDevice())
        {
            SpeechRecognizerListener listener = GameObject.FindObjectOfType<SpeechRecognizerListener>();
            listener.onAuthorizationStatusFetched.AddListener(OnAuthorizationStatusFetched);
            listener.onErrorDuringRecording.AddListener(OnError);
            listener.onErrorOnStartRecording.AddListener(OnError);
            listener.onFinalResults.AddListener(OnFinalResult);
            listener.onPartialResults.AddListener(OnPartialResult);
            SpeechRecognizer.RequestAccess();

            SpeechRecognizer.StartRecording(true);
        }
    }

    private void SelectedOption(string result)
    {
        result = result.ToLower();

        if(result.Contains(Texts.ZOE_ZOE) || result.Contains(Texts.ZOE_ZOI) 
            || result.Contains(Texts.ZOE_ZOUI) || result.Contains(Texts.ZOE_ZOUE))
        {
            ZoeAction();
            return;
        }

        if(result.Contains(Texts.ZOE_CURIOSITY))
        {
            CuriosityAction();
            return;
        }

        if (result.Contains(Texts.ZOE_ENTER_IN_THIS_PLANET))
        {
            EnterInThisPlanetAction();
            return;
        }

        if (result.Contains(Texts.ZOE_TAKE_ME_TO_SPACE))
        {
            GoToSpaceAction();
            return;
        }

        if (result.Contains(Texts.ZOE_TAKE_ME_TO_MERCURY))
        {
            GoToPlanetAction(1, Texts.EVENTS_MERCURY);
            return;
        }

        if (result.Contains(Texts.ZOE_TAKE_ME_TO_VENUS))
        {
            GoToPlanetAction(2, Texts.EVENTS_VENUS);
            return;
        }

        if (result.Contains(Texts.ZOE_TAKE_ME_TO_EARTH))
        {
            GoToPlanetAction(3, Texts.EVENTS_EARTH);
            return;
        }

        if (result.Contains(Texts.ZOE_TAKE_ME_TO_MARS))
        {
            GoToPlanetAction(4, Texts.EVENTS_MARS);
            return;
        }

        if (result.Contains(Texts.ZOE_TAKE_ME_TO_JUPITER))
        {
            GoToPlanetAction(5, Texts.EVENTS_JUPITER);
            return;
        }

        if (result.Contains(Texts.ZOE_TAKE_ME_TO_SATURN))
        {
            GoToPlanetAction(6, Texts.EVENTS_SATURN);
            return;
        }

        if (result.Contains(Texts.ZOE_TAKE_ME_TO_URANUS))
        {
            GoToPlanetAction(7, Texts.EVENTS_URANUS);
            return;
        }

        if (result.Contains(Texts.ZOE_TAKE_ME_TO_NEPTUNE))
        {
            GoToPlanetAction(8, Texts.EVENTS_NEPTUNE);
            return;
        }

    }

    private void Update()
    {
        if (!SpeechRecognizer.IsRecording())
        {
            SpeechRecognizer.StartRecording(true);
        }
    }

    public void OnFinalResult(string result)
    {
        SelectedOption(result);
    }

    public void OnPartialResult(string result)
    {
        SelectedOption(result);
    }

    public void OnAuthorizationStatusFetched(AuthorizationStatus status)
    {
        switch (status)
        {
            case AuthorizationStatus.Authorized:
                //a
                break;
            default:
                //b
                break;
        }
    }

    public void OnError(string error)
    {
        Debug.LogError(error);
    }

    private void ZoeAction()
    {
        if (zoeCanTalk)
        {
            StartCoroutine(TimeToTalk(1));

            zoeIsListening = true;
            PlayerCommand(1);
        }
    }

    private void CuriosityAction()
    {
        if (zoeIsListening && GlobalProperties.idPlanet != 0)
        {
            PlayerCommand(5);
            SetZoeListening();
        }
    }

    private void GoToPlanetAction(int idPlanet, string planet)
    {
        if (zoeIsListening)
        {
            if (SceneManager.GetActiveScene().name == Texts.SCENES_SPACESHIP)
            {
                if (idPlanet != GlobalProperties.idPlanet)
                {
                    ChosenPlanet(planet);
                    this.idPlanet = idPlanet;
                    GlobalProperties.planetTag = planet;
                    GlobalProperties.idPlanet = idPlanet;
                    SetZoeListening();
                }
                else
                {
                    PlayerCommand(4);
                }
            }
        }
    }

    private void EnterInThisPlanetAction()
    {
        idPlanet = GlobalProperties.idPlanet;

        if (zoeIsListening && idPlanet != 0)
        {
            if (idPlanet == 1 || idPlanet == 2 || idPlanet == 4)
            {
                SaidToComeInPlanet(idPlanet);
                idPlanet = 0;
                SetZoeListening();
            }
            else if (idPlanet == 5 || idPlanet == 6 || idPlanet == 7 || idPlanet == 8)
            {
                PlayerCommand(2);
                SetZoeListening();
            }
            else if (idPlanet == 3)
            {
                PlayerCommand(3);
                SetZoeListening();
            }

        }
    }

    private void GoToSpaceAction()
    {
        if (zoeIsListening && SceneManager.GetActiveScene().name != Texts.SCENES_SPACESHIP)
        {
            LeftThePlanet(SceneManager.GetActiveScene().name);
            SetZoeListening();
        }
        else if (zoeIsListening && SceneManager.GetActiveScene().name == Texts.SCENES_SPACESHIP)
        {
            //falar pra deixar de ser tonto
        }
    }

    private void SetZoeListening()
    {
        zoeIsListening = !zoeIsListening;
    }


    IEnumerator TimeToTalk(int idCommand)
    {
        yield return new WaitForSeconds(5);

        if (idCommand == 1)
        {
            zoeIsListening = false;
        }
    }
}