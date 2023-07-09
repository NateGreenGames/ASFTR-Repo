using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource audioSource;

    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";
    public float targetValue = 0;
    public float durationValue = 5;


    // Sound clips
    [SerializeField] private AudioClip running;
    [SerializeField] private AudioClip cooking;
    [SerializeField] private AudioClip clicking;

    // BG Music 
    [SerializeField] private AudioClip mainMenu;
    [SerializeField] private AudioClip[] levels;



    private void Awake()
    {
        LoadVolume();
    }

    private void Start()
    {
        StartBGM();
    }

    private void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, .4f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, .4f);
    }


    public void ButtonSFX()
    {
        AudioClip clip = clicking;
        audioSource.PlayOneShot(clip);
    }

    IEnumerator SongFadeIn(float _endValue, float _duration) //Lerps AudioSource Volume (NOT MIXER) from targetValue to _duration
    {
        float time = 0;
        float startValue = audioSource.volume;

        while (time < _duration)
        {
            audioSource.volume = Mathf.Lerp(startValue, _endValue, time / _duration);
            time += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = _endValue;
    }

    IEnumerator StartBGM()
    {
        audioSource.PlayOneShot(mainMenu);
        StartCoroutine(SongFadeIn(targetValue, durationValue));
        yield return new WaitForSeconds(mainMenu.length);
        StartCoroutine(StartBGM());
    }
}
