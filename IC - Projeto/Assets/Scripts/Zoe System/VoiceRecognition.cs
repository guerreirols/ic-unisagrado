using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class VoiceRecognition : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    private bool zoeIsListening;
    private static bool objectAlreadyExists = false;

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

    void Start() 
    {
        if(actions.Count() == 0)
        {
            actions.Add(Comands.ZOI, ZoeAction);
            actions.Add(Comands.ZOE, ZoeAction);
            actions.Add(Comands.TAKE_ME_TO_MARS, MarteAction);
            actions.Add(Comands.TAKE_ME_TO_SPACE, SpaceAction);
        }
      
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    void ZoeAction()
    {
        Debug.Log("Oi");
        SetZoeListening();
    }

    void MarteAction()
    {
        if(zoeIsListening)
        {
            SceneManager.LoadScene(Scenes.MARS);
            SetZoeListening();
        }     
    }

    void SpaceAction()
    {
        if (zoeIsListening)
        {
            SceneManager.LoadScene(Scenes.SPACESHIP);
            SetZoeListening();
        }      
    }

    void SetZoeListening()
    {
        zoeIsListening = !zoeIsListening;
    }

    void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        actions[speech.text].Invoke();
    }
}



