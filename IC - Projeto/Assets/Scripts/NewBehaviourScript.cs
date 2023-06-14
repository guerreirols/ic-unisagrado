using UnityEngine;
using UnityEngine.Android;

public class NewBehaviourScript : MonoBehaviour
{
    private AndroidJavaObject speechRecognitionPlugin;

    public GameObject a;

    bool testee = true;

    private void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }

        speechRecognitionPlugin = new AndroidJavaObject("com.iclg.voicecontroller");
        speechRecognitionPlugin.Call("startListening", GetTargetString());     
    }


    private void Update()
    {
 

        // Verifique se foi encontrada uma correspondência
        bool matchFound = speechRecognitionPlugin.Get<bool>("isMatchFound");
        if (matchFound)
        {
            // Faça algo quando a correspondência for encontrada
            teste();
            a.SetActive(testee);          
            // Faça as ações necessárias aqui
        }
    }

    void teste()
    {
        testee = !testee;
    }

    private string GetTargetString()
    {
        // Retorne a string de destino que você deseja verificar na fala
        return "Oi";
    }
}
