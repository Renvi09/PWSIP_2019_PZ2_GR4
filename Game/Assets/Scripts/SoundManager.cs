using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> musicLobby;
    [SerializeField]
    private List<AudioClip> musicDungeon;
    AudioSource audioSource;
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {

            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();

            }
            return instance;
        }


    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioSource = AddAudio(musicLobby[Random.Range(0, musicLobby.Count-1)], false, false, 0.5f);
        audioSource.Play();

    }
    private void Update()
    {
        if(!audioSource.isPlaying && GameManager.Instance.maps.Count==0)
        {
            audioSource=AddAudio(musicLobby[Random.Range(0, musicLobby.Count-1)],false,false,0.5f);
            audioSource.Play();
           
        }

        if (!audioSource.isPlaying && GameManager.Instance.maps.Count >0)
        {
            audioSource = AddAudio(musicLobby[Random.Range(0, musicLobby.Count - 1)], false, false, 0.5f);
            audioSource.Play();

        }
    }
    public void DungeonPlayMusic()
    {
        audioSource.Stop();
        audioSource = AddAudio(musicDungeon[Random.Range(0, musicLobby.Count - 1)], false, false, 0.5f);
        audioSource.Play();
    }
    public void LobbyPlayMusic()
    {
        audioSource.Stop();
        audioSource = AddAudio(musicLobby[Random.Range(0, musicLobby.Count - 1)], false, false, 0.5f);
        audioSource.Play();
    }
    //Funkcja pozwalajaca na tworzenie nowych zrodel audio
    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {

        AudioSource newAudioSource = audioSource;

        newAudioSource.clip = clip;
        newAudioSource.loop = loop;
        newAudioSource.playOnAwake = playAwake;
        newAudioSource.volume = vol; 

        return newAudioSource;

    }
}
