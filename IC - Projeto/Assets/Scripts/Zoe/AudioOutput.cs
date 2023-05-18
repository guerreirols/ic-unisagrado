using UnityEngine;

public class AudioOutput : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] zoeAudios;

    public delegate void ZoeSaidHandler(AudioSource currentAudio);
    public event ZoeSaidHandler ZoeSaid;

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

    public void OnPlayerCommand(int idCommand)
    {
        switch (idCommand)
        {
            case 1:
                Hello();
                break;
        }
    }

    private void Hello()
    {
        AudioSource currentAudio = zoeAudios[Random.Range(0, 5)];
        currentAudio.Play();
        ZoeSaid(currentAudio);
    }
}
