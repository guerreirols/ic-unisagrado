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

    [SerializeField]
    private AudioSource[] mercuryCuriosities;

    [SerializeField]
    private AudioSource[] venusCuriosities;

    [SerializeField]
    private AudioSource[] earthCuriosities;

    [SerializeField]
    private AudioSource[] marsCuriosities;

    [SerializeField]
    private AudioSource[] jupiterCuriosities;

    [SerializeField]
    private AudioSource[] saturnCuriosities;

    [SerializeField]
    private AudioSource[] uranusCuriosities;

    [SerializeField]
    private AudioSource[] neptuneCuriosities;

 

    public delegate void ZoeSaidHandler(AudioSource currentAudio);
    public event ZoeSaidHandler ZoeSaid;

    public void OnPlayerCommand(int idCommand)
    {
        switch (idCommand)
        {
            case 1:
                PlayAudio(helloAudios[Random.Range(0, 5)]);
                break;
            case 2:
                PlayAudio(gaseousPlanetAudios[Random.Range(0, 3)]);
                break;
            case 3:
                PlayAudio(earthAudios[Random.Range(0, 2)]);
                break;
            case 4:
                PlayAudio(samePlanetAudios[Random.Range(0, 2)]);
                break;
            case 5:
                PlayPlanetCuriosity();
                break;

        }
    }

    private void PlayPlanetCuriosity()
    {
        switch(GlobalProperties.idPlanet)
        {
            case 1:

                int curiosityMercuryIndex = GlobalProperties.curiosityMercuryIndex;

                if (curiosityMercuryIndex > 9)
                {
                    GlobalProperties.curiosityMercuryIndex = 0;
                    curiosityMercuryIndex = 0;
                }

                PlayAudio(mercuryCuriosities[curiosityMercuryIndex]);
                GlobalProperties.curiosityMercuryIndex++;
                break;

            case 2:

                int curiosityVenusIndex = GlobalProperties.curiosityVenusIndex;

                if (curiosityVenusIndex > 9)
                {
                    GlobalProperties.curiosityVenusIndex = 0;
                    curiosityVenusIndex = 0;
                }

                PlayAudio(venusCuriosities[curiosityVenusIndex]);
                GlobalProperties.curiosityVenusIndex++;
                break;

            case 3:

                int curiosityEarthIndex = GlobalProperties.curiosityEarthIndex;

                if (curiosityEarthIndex > 7)
                {
                    GlobalProperties.curiosityEarthIndex = 0;
                    curiosityEarthIndex = 0;
                }

                PlayAudio(earthCuriosities[curiosityEarthIndex]);
                GlobalProperties.curiosityEarthIndex++;
                break;

            case 4:

                int curiosityMarsIndex = GlobalProperties.curiosityMarsIndex;

                if (curiosityMarsIndex > 9)
                {
                    GlobalProperties.curiosityMarsIndex = 0;
                    curiosityMarsIndex = 0;
                }

                PlayAudio(marsCuriosities[curiosityMarsIndex]);
                GlobalProperties.curiosityMarsIndex++;
                break;

            case 5:

                int curiosityJupiterIndex = GlobalProperties.curiosityJupiterIndex;

                if (curiosityJupiterIndex > 9)
                {
                    GlobalProperties.curiosityJupiterIndex = 0;
                    curiosityJupiterIndex = 0;
                }

                PlayAudio(jupiterCuriosities[curiosityJupiterIndex]);
                GlobalProperties.curiosityJupiterIndex++;
                break;

            case 6:

                int curiositySaturnIndex = GlobalProperties.curiositySaturnIndex;

                if (curiositySaturnIndex > 8)
                {
                    GlobalProperties.curiositySaturnIndex = 0;
                    curiositySaturnIndex = 0;
                }

                PlayAudio(saturnCuriosities[curiositySaturnIndex]);
                GlobalProperties.curiositySaturnIndex++;
                break;

            case 7:

                int curiosityUranusIndex = GlobalProperties.curiosityUranusIndex;

                if (curiosityUranusIndex > 8)
                {
                    GlobalProperties.curiosityUranusIndex = 0;
                    curiositySaturnIndex = 0;
                }

                PlayAudio(uranusCuriosities[curiosityUranusIndex]);
                GlobalProperties.curiosityUranusIndex++;
                break;

            case 8:

                int curiosityNeptuneIndex = GlobalProperties.curiosityNeptuneIndex;

                if (curiosityNeptuneIndex > 4)
                {
                    GlobalProperties.curiosityNeptuneIndex = 0;
                    curiosityNeptuneIndex = 0;
                }

                PlayAudio(neptuneCuriosities[curiosityNeptuneIndex]);
                GlobalProperties.curiosityNeptuneIndex++;
                break;
        }
    }

    private void PlayAudio(AudioSource currentAudio)
    {
        currentAudio.Play();
        ZoeSaid(currentAudio);
    }
}
