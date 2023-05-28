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

    private void Start() 
    {
        actions.Clear();
        if(actions.Count() == 0)
        {
            actions.Add(Texts.ZOE_ZOI, ZoeAction);
            actions.Add(Texts.ZOE_ZOE, ZoeAction);
            actions.Add(Texts.ZOE_ZOUI, ZoeAction);
            actions.Add(Texts.ZOE_ZOUE, ZoeAction);

            actions.Add(Texts.ZOE_CURIOSITY, Curiosity);

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

    private void Curiosity()
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
                if(idPlanet != GlobalProperties.idPlanet)
                {
                    ChosenPlanet(planet);
                    this.idPlanet = idPlanet;
                    GlobalProperties.planetTag = planet;
                    GlobalProperties.idPlanet = idPlanet;
                    SetZoeListening();
                }
                else {
                    PlayerCommand(4);
                }
            }
            else
            {
                PlayerCommand(5);
            }
        }
    }

    private void EnterInThisPlanetAction()
    {
        idPlanet = GlobalProperties.idPlanet;

        if(zoeIsListening && idPlanet != 0)
        {
            if(idPlanet == 1 || idPlanet == 2 ||  idPlanet == 4)
            {
                SaidToComeInPlanet(idPlanet);
                idPlanet = 0;
                SetZoeListening();
            }
            else if(idPlanet == 5 || idPlanet == 6 || idPlanet == 7 || idPlanet == 8)
            {
                PlayerCommand(2);
                SetZoeListening();
            }
            else if(idPlanet == 3)
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