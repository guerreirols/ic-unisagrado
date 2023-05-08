using UnityEngine;

public class AudioOutput : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] zoeAudios;

    public delegate void ZoeSaidHandler(AudioSource currentAudio);
    public event ZoeSaidHandler ZoeSaid;

    private void Hello()
    {
        AudioSource currentAudio = zoeAudios[Random.Range(0, 5)];
        currentAudio.Play();
        ZoeSaid(currentAudio);
    }

    public void OnPlayerCommand(int idCommand)
    {
        switch(idCommand)
        {
            case 1:
                Hello();
                break;
        }
    }
}
