using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    // Singleton instance
    public static AudioManager Instance { get; private set; }

    public AudioClip ambianceSautDeClope;
    public AudioClip victoireSautDeClope;
    public AudioClip defaiteSautDeClope;
    public AudioClip outilDentiste;
    public AudioClip tirBaby;
    public AudioClip butBaby;
    public AudioClip loupeBaby;
    public AudioClip clopeCorbeille;
    public AudioClip herbeBrule;
    public AudioClip victoireCorbeille;
    public AudioClip victoireDents;
    public AudioClip tapeTaffe;
    public AudioClip victoireTaffe;
    public AudioClip defaiteTaffe;
    public AudioClip hearthBeat;

    [SerializeField] AudioClip music;

    [SerializeField] AudioSource effectAudioSource;
    [SerializeField] AudioSource musicAudioSource;

    private Dictionary<string, AudioClip> audioClips;

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        musicAudioSource.loop = true;
        musicAudioSource.clip = music;
        musicAudioSource.Play();


        audioClips = new Dictionary<string, AudioClip>
        {
            { "Ambiance saut de clope", ambianceSautDeClope },
            { "Victoire saut de clope", victoireSautDeClope },
            { "Defaite saut de clope", defaiteSautDeClope },
            { "Outil dentiste", outilDentiste },
            { "Tir Baby", tirBaby },
            { "But Baby", butBaby },
            { "Loupe Baby", loupeBaby },
            { "Clope Corbeille", clopeCorbeille },
            { "Herbe Brule", herbeBrule },
            { "Victoire Corbeille", victoireCorbeille },
            { "Victoire Dents", victoireDents },
            { "Tape taffe", tapeTaffe },
            { "Victoire Taffe", victoireTaffe },
            { "Defaite Taffe", defaiteTaffe },
            { "Hearth Beat", hearthBeat }
        };
    }

    public void PlayAudio(string situation)
    {
        if (audioClips.ContainsKey(situation))
        {
            effectAudioSource.clip = audioClips[situation];
            effectAudioSource.Play();
            print(situation);
        }
        else
        {
            Debug.LogWarning("Situation not found: " + situation);
        }
    }

    public void StopAudio()
    {
        if (effectAudioSource.isPlaying)
        {
            effectAudioSource.Stop();
        }
    }
}
