using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager sndm
    {
        get
        {
            if (_instance == null)
            {

                _instance = FindObjectOfType<SoundManager>();

                if (_instance == null)
                {
                    GameObject prefab = Resources.Load<GameObject>("SoundManagerDB");
                    if (prefab != null)
                    {
                        GameObject instance = Instantiate(prefab);
                        _instance = instance.GetComponent<SoundManager>();

                        if (_instance == null)
                        {
                            Debug.LogError("Soundmanager prefab does not contain sound manager class!");
                        }
                        else
                        {
                            Debug.Log("SoundManager prefab was successfully created.");
                        }
                    }
                    else
                    {
                        Debug.LogError("Soundmanager prefab does not exist or not found");
                    }
                }
            }
            return _instance;
        }
    }

    public AudioMixerGroup mixerGroup;

    [Range(0f, 1f)] public float MusicVolume = 0.5f;
    [Range(0f, 1f)] public float AmbientVolume = 0.5f;
    [Range(0f, 1f)] public float SoundVolume = 0.5f;

    public SoundClass[] sounds;
    private Dictionary<string, SoundClass> soundDictionary;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeSounds();
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeOnLoad()
    {
        var soundManagerInstance = sndm;
    }
    private void InitializeSounds()
    {
        soundDictionary = new Dictionary<string, SoundClass>();

        foreach (SoundClass s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = mixerGroup;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            soundDictionary[s.name] = s;
        }
    }

    public void Play(string sound)
    {
        if (soundDictionary.TryGetValue(sound, out SoundClass s))
        {
            s.source.pitch = s.pitch * UnityEngine.Random.Range(1f - s.pitchVariance / 2f, 1f + s.pitchVariance / 2f);

            UpdateSourceVolume(s);
            s.source.Play();
        }
        else
        {
            Debug.LogWarning("Sound: " + sound + " not found!");
        }
    }

    public void Stop(string sound)
    {
        if (soundDictionary.TryGetValue(sound, out SoundClass s) && s.source != null)
        {
            s.source.Stop();
        }
        else
        {
            Debug.LogWarning("Sound: " + sound + " not found!");
        }
    }

    public void UpdateMusicVolume(float musVolume)
    {
        MusicVolume = musVolume;
        UpdateVolumes();
        Debug.Log("Mus volume updated to: " + musVolume);
    }

    public void UpdateAmbientVolume(float ambVolume)
    {
        AmbientVolume = ambVolume;
        UpdateVolumes();
        Debug.Log("Amb volume updated to: " + ambVolume);
    }

    public void UpdateSoundVolume(float sndVolume)
    {
        SoundVolume = sndVolume;
        UpdateVolumes();
        Debug.Log("Snd volume updated to: " + sndVolume);
    }

    private void UpdateVolumes()
    {
        foreach (var s in soundDictionary.Values)
        {
            if (s.source != null && s.source.isPlaying)
            {
                UpdateSourceVolume(s);
            }
        }
    }

    private void UpdateSourceVolume(SoundClass s)
    {
        float volume = s.volume * UnityEngine.Random.Range(1f - s.volumeVariance / 2f, 1f + s.volumeVariance / 2f);
        if (s.Music)
        {
            s.source.volume = volume * MusicVolume;
        }
        else if (s.Sound)
        {
            s.source.volume = volume * SoundVolume;
        }
        else if (s.Ambient)
        {
            s.source.volume = volume * AmbientVolume;
        }
    }

    public void StopAllSounds()
    {
        foreach (var sound in soundDictionary.Values)
        {
            if (sound.source != null && sound.source.isPlaying)
            {
                sound.source.Stop();
            }
        }
    }
    public bool IsPlaying(string sound)
    {
        if (soundDictionary.TryGetValue(sound, out SoundClass s) && s.source != null)
        {
            return s.source.isPlaying;
        }
        else
        {
            Debug.LogWarning("Checked sound: " + sound + " not found or has no AudioSource!");
            return false;
        }
    }

}
