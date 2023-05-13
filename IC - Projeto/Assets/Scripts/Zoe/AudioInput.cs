using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class AudioInput : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    private bool zoeIsListening;
    private static bool objectAlreadyExists = false;

    private int idPlanet;

    public delegate void ChosenPlanetHandler(string msg);
    public event ChosenPlanetHandler ChosenPlanet;

    public delegate void SaidToComeInPlanetHandler(int idPlanet);
    public event SaidToComeInPlanetHandler SaidToComeInPlanet;

    public delegate void PlayerCommandHandler(int idCommand);
    public event PlayerCommandHandler PlayerCommand;

    private void Awake()
    {
        if (!objectAlreadyExists)
        {
            objectAlreadyExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        if(actions.Count() == 0)
        {
            actions.Add(Texts.ZOE_ZOI, ZoeAction);
            actions.Add(Texts.ZOE_ZOE, ZoeAction);

            actions.Add(Texts.ZOE_TAKE_ME_TO_MERCURY, GoToMercuryAction);
            actions.Add(Texts.ZOE_TAKE_ME_TO_VENUS, GoToVenusAction);
            actions.Add(Texts.ZOE_TAKE_ME_TO_EARTH, GoToEarthAction);
            actions.Add(Texts.ZOE_TAKE_ME_TO_MARS, GoToMarsAction);
            actions.Add(Texts.ZOE_TAKE_ME_TO_JUPITER, GoToJupiterAction);
            actions.Add(Texts.ZOE_TAKE_ME_TO_SATURN, GoToSaturnAction);
            actions.Add(Texts.ZOE_TAKE_ME_TO_URANUS, GoToUranusAction);
            actions.Add(Texts.ZOE_TAKE_ME_TO_NEPTUNE, GoToNeptuneAction);

            actions.Add(Texts.ZOE_ENTER_IN_THIS_PLANET, EnterInThisPlanetAction);

            actions.Add(Texts.ZOE_TAKE_ME_TO_SPACE, SpaceAction);
        }
      
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void ZoeAction()
    {
        zoeIsListening = true;
        PlayerCommand(1);
    }

    #region Planets Commands
    private void GoToMercuryAction()
    {
        if (zoeIsListening)
        {
            ChosenPlanet(Texts.EVENTS_MERCURY);
            idPlanet = 1;
            SetZoeListening();
        }
    }

    private void GoToVenusAction()
    {
        if (zoeIsListening)
        {
            ChosenPlanet(Texts.EVENTS_VENUS);
            idPlanet = 2;
            SetZoeListening();
        }
    }

    private void GoToEarthAction()
    {
        if (zoeIsListening)
        {
            ChosenPlanet(Texts.EVENTS_EARTH);
            idPlanet = 3;
            SetZoeListening();
        }
    }

    private void GoToMarsAction()
    {
        if (zoeIsListening)
        {
            ChosenPlanet(Texts.EVENTS_MARS);
            idPlanet = 4;
            SetZoeListening();
        }
    }

    private void GoToJupiterAction()
    {
        if (zoeIsListening)
        {
            ChosenPlanet(Texts.EVENTS_JUPITER);
            idPlanet = 5;
            SetZoeListening();
        }
    }

    private void GoToSaturnAction()
    {
        if (zoeIsListening)
        {
            ChosenPlanet(Texts.EVENTS_SATURN);
            idPlanet = 6;
            SetZoeListening();
        }
    }

    private void GoToUranusAction()
    {
        if (zoeIsListening)
        {
            ChosenPlanet(Texts.EVENTS_URANUS);
            idPlanet = 7;
            SetZoeListening();
        }
    }

    private void GoToNeptuneAction()
    {
        if (zoeIsListening)
        {
            ChosenPlanet(Texts.EVENTS_NEPTUNE);
            idPlanet = 8;
            SetZoeListening();
        }
    }
    #endregion

    private void EnterInThisPlanetAction()
    {
        if(zoeIsListening && idPlanet != 0)
        {
            PlayerCommand(2);
            SaidToComeInPlanet(idPlanet);
            idPlanet = 0;
            SetZoeListening();
        }
    }

    private void SpaceAction()
    {
        if (zoeIsListening)
        {
            SceneManager.LoadScene(Texts.SCENES_SPACESHIP);
            SetZoeListening();
        }      
    }

    private void SetZoeListening()
    {
        zoeIsListening = !zoeIsListening;
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        actions[speech.text].Invoke();
    }
}