using UnityEngine;

public class AudioOutput : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] helloAudios;

    [SerializeField]
    private AudioSource[] gaseousPlanetAudios;

    [SerializeField]
    private AudioSource[] earthAudios;

    [SerializeField]
    private AudioSource[] samePlanetAudios;

    public delegate void ZoeSaidHandler(AudioSource currentAudio);
    public event ZoeSaidHandler ZoeSaid;

    public void OnPlayerCommand(int idCommand)
    {
        switch (idCommand)
        {
            case 1:
                Hello();
                break;
            case 2:
                GaseousPlanet();
                break;
            case 3:
                Earth();
                break;
            case 4:
                SamePlanet();
                break;
        }
    }

    private void Hello()
    {
        AudioSource currentAudio = helloAudios[Random.Range(0, 5)];
        currentAudio.Play();
        ZoeSaid(currentAudio);
    }

    private void GaseousPlanet()
    {
        AudioSource currentAudio = gaseousPlanetAudios[Random.Range(0, 3)];
        currentAudio.Play();
        ZoeSaid(currentAudio);
    }

    private void Earth()
    {
        AudioSource currentAudio = earthAudios[Random.Range(0, 2)];
        currentAudio.Play();
        ZoeSaid(currentAudio);
    }

    private void SamePlanet()
    {
        AudioSource currentAudio = samePlanetAudios[Random.Range(0, 2)];
        currentAudio.Play();
        ZoeSaid(currentAudio);
    }
}
