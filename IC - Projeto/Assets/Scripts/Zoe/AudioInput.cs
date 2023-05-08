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

    public delegate void ChosenPlanetHandler(string msg);
    public event ChosenPlanetHandler ChosenPlanet;

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
            actions.Add(Texts.ZOE_TAKE_ME_TO_MARS, MarteAction);
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

    private void MarteAction()
    {
        if(zoeIsListening)
        {
            if(ChosenPlanet != null)
            {
                ChosenPlanet(Texts.EVENTS_MARS);
            }

            //SceneManager.LoadScene(Scenes.MARS);
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



