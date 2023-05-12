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

    /* Mercury = 1 | Venus = 2 | Earth = 3 | Mars = 4      *
     * Jupiter = 5 | Saturn = 6 | Uranus = 7 | Neptune = 8 */
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
            actions.Add(Texts.ZOE_TAKE_ME_TO_MARS, GoToMarsAction);
            actions.Add(Texts.ZOE_ENTER_IN_THIS_PLANET, EnterInThisPlanetAction);

            actions.Add(Texts.ZOE_TAKE_ME_TO_SPACE, SpaceAction);
        }
      
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void ZoeAction()
    {
        SetZoeListening();
        PlayerCommand(1);
    }

    private void GoToMarsAction()
    {
        if(zoeIsListening)
        {
            ChosenPlanet(Texts.EVENTS_MARS);         
            idPlanet = 4;
            SetZoeListening();
        }     
    }

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



