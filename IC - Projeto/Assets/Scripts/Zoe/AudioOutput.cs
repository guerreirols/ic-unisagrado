﻿using UnityEngine;

public class AudioOutput : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] zoeAudios;

    public delegate void ZoeSaidHandler(AudioSource currentAudio);
    public event ZoeSaidHandler ZoeSaid;

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