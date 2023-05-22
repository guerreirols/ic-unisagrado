using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioInput : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    public static bool zoeIsListening;

    private int idPlanet;

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

    /*private static bool objectAlreadyExists = false;

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
    }*/

    private void Start() 
    {
        actions.Clear();
        if(actions.Count() == 0)
        {
            actions.Add(Texts.ZOE_ZOI, ZoeAction);
            actions.Add(Texts.ZOE_ZOE, ZoeAction);

            actions.Add(Texts.ZOE_TAKE_ME_TO_MERCURY, () => GoToPlanetAction(1, Texts.EVENTS_MERCURY));
            actions.Add(Texts.ZOE_TAKE_ME_TO_VENUS, () => GoToPlanetAction(2, Texts.EVENTS_VENUS));
            actions.Add(Texts.ZOE_TAKE_ME_TO_EARTH, () => GoToPlanetAction(3, Texts.EVENTS_EARTH));
            actions.Add(Texts.ZOE_TAKE_ME_TO_MARS, () => GoToPlanetAction(4,Texts.EVENTS_MARS));
            actions.Add(Texts.ZOE_TAKE_ME_TO_JUPITER, () => GoToPlanetAction(5, Texts.EVENTS_JUPITER));
            actions.Add(Texts.ZOE_TAKE_ME_TO_SATURN, () => GoToPlanetAction(6, Texts.EVENTS_SATURN));
            actions.Add(Texts.ZOE_TAKE_ME_TO_URANUS, () => GoToPlanetAction(7, Texts.EVENTS_URANUS));
            actions.Add(Texts.ZOE_TAKE_ME_TO_NEPTUNE, () => GoToPlanetAction(8, Texts.EVENTS_NEPTUNE));

            actions.Add(Texts.ZOE_ENTER_IN_THIS_PLANET, EnterInThisPlanetAction);

            actions.Add(Texts.ZOE_TAKE_ME_TO_SPACE, GoToSpaceAction);
        }
      
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void ZoeAction()
    {
        if(zoeCanTalk)
        {
            StartCoroutine(TimeToTalk(1));

            zoeIsListening = true;
            PlayerCommand(1);
        }      
    }

    private void GoToPlanetAction(int idPlanet, string planet)
    {
        if (zoeIsListening)
        {
            if (SceneManager.GetActiveScene().name == Texts.SCENES_SPACESHIP)
            {
                ChosenPlanet(planet);
                this.idPlanet = idPlanet;
                this.currentPlanet = planet;
                SetZoeListening();
            }
            else
            {
                PlayerCommand(2);
            }
        }
    }

    private void EnterInThisPlanetAction()
    {
        if(zoeIsListening && idPlanet != 0)
        {
            PlayerCommand(3);
            SaidToComeInPlanet(idPlanet);
            idPlanet = 0;
            SetZoeListening();
        }
    }

    private void GoToSpaceAction()
    {
        if (zoeIsListening && SceneManager.GetActiveScene().name != Texts.SCENES_SPACESHIP)
        {
            LeftThePlanet(SceneManager.GetActiveScene().name);
            SetZoeListening();
        } 
        else if(zoeIsListening && SceneManager.GetActiveScene().name == Texts.SCENES_SPACESHIP)
        {
            //falar pra deixar de ser tonto
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

    IEnumerator TimeToTalk(int idCommand)
    {
        yield return new WaitForSeconds(5);

        if(idCommand == 1)
        {
            zoeIsListening = false;
        }
    }
}