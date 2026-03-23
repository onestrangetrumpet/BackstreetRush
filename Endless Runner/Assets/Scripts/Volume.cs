using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
    {
    public static Volume Instance;

    public AudioMixer mainMixer;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetMusicVolume(float volume)
    {
        // Slider gives 0–1, convert to dB
        float dB = Mathf.Log10(volume <= 0 ? 0.0001f : volume) * 20f;

        mainMixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetFloat("MusicVolume", dB);
    }
    public void SetSFXVolume(float volume)
    {
        float dB = Mathf.Log10(volume <= 0 ? 0.0001f : volume) * 20f;

        mainMixer.SetFloat("SFXVolume", dB);
        PlayerPrefs.SetFloat("SFXVolume", dB);
    }
    public void SetMasterVolume(float volume)
    {
        float dB = Mathf.Log10(volume <= 0 ? 0.0001f : volume) * 20f;

        mainMixer.SetFloat("MasterVolume", dB);
        PlayerPrefs.SetFloat("MasterVolume", dB);
    }
     public void LoadSavedVolume()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0f);  // 0 dB default
        mainMixer.SetFloat("MusicVolume", savedMusicVolume);

        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0f);  // 0 dB default
        mainMixer.SetFloat("SFXVolume", savedSFXVolume);

        float savedMasterVolume = PlayerPrefs.GetFloat("MasterVolume", 0f);  // 0 dB default
        mainMixer.SetFloat("MasterVolume", savedMasterVolume);
    }
    }
