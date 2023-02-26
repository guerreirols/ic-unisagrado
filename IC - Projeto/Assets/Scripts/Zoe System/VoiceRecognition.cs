/*using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class VoiceRecognition : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    private bool zoeIsListening;

    void Start() 
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }

        actions.Add(Comands.ZOI, ZoeAction);
        actions.Add(Comands.ZOE, ZoeAction);
        actions.Add(Comands.TAKE_ME_TO_MARS, MarteAction);
        actions.Add(Comands.TAKE_ME_TO_SPACE, SpaceAction);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    void ZoeAction()
    {
        Debug.Log("Oi");
    }

    void MarteAction()
    {
        if(zoeIsListening)
        {
            SceneManager.LoadScene(Scenes.MARS);
        }     
    }

    void SpaceAction()
    {
        if (zoeIsListening)
        {
            SceneManager.LoadScene(Scenes.SPACESHIP);
        }      
    }

    void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        actions[speech.text].Invoke();
    }
}*/

using UnityEngine;
using UnityEngine.Android;
using System.Collections;
using UnityEngine.SceneManagement;

public class VoiceRecognition : MonoBehaviour
{
    private AndroidJavaObject speechRecognizer;
    private bool isRecording = false;

    void Start()
    {
        UnityEngine.XR.XRSettings.enabled = true;

        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        speechRecognizer = new AndroidJavaObject("android.speech.RecognizerIntent");
        speechRecognizer.Call<AndroidJavaObject>("putExtra", speechRecognizer.GetStatic<string>("EXTRA_LANGUAGE_MODEL"), speechRecognizer.GetStatic<string>("LANGUAGE_MODEL_FREE_FORM"));
    }

    void Update()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }


        if (!isRecording)
        {
            print("aaa");
            isRecording = true;
            speechRecognizer.Call("startListening", speechRecognizer);
        }
    }

    void OnApplicationQuit()
    {
        if (speechRecognizer != null)
        {
            speechRecognizer.Dispose();
        }
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Escape)
        {
            Application.Quit();
        }
    }

    void ProcessVoiceCommands(string voiceCommand)
    {
        if (voiceCommand.ToLower().Contains(Comands.TAKE_ME_TO_MARS))
        {
            SceneManager.LoadScene(Scenes.MARS);
        }
    }
}



