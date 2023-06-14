using UnityEngine;
using UnityEngine.SceneManagement;
using KKSpeech;

public class MenuAudio: MonoBehaviour
{

    [SerializeField] 
    private GameObject menu;

    [SerializeField]
    private GameObject tutorial;

    [SerializeField] 
    private GameObject credits;

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

        if (result.Contains("iniciar"))
        {
            StartGame();
            return;
        }

        if (result.Contains("instruções"))
        {
            Tutorial();
            return;
        }

        if (result.Contains("créditos"))
        {
            Credits();
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


    public void StartGame()
    {
        SceneManager.LoadScene(Texts.SCENES_SPACESHIP);
    }

    public void Tutorial()
    {
        menu.SetActive(false);
        tutorial.SetActive(true);
        credits.SetActive(false);
    }

    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
        tutorial.SetActive(false);
    }
}
