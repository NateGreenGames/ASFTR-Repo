using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{

    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    public const string MIXER_MUSIC = "MusicVol";
    public const string MIXER_SFX = "SoundVol";

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, .4f);
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, .4f);
    }

    public void SetMusicVolume(float _volume)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(_volume) * 20);
    }

    public void SetSFXVolume(float _volume)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(_volume) * 20);
    }

}
