using UnityEngine;
using UnityEngine.UI;


public class CanvasOptions : MonoBehaviour
{
    /*
    [NamedArray(typeof(eMixers))] public Slider[] sliders;

    GameManager gm;
    private void Start()
    {
        gm = GameManager.gm;
        
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].value = gm.audioManager.volume[i];
        }
        
    }
    public void OnMusicValueChanged()
    {
        gm.audioManager.SetMixerLevel(eMixers.music, sliders[(int)eMixers.music].value, "musicVol");
    }

    public void OnSoundValueChanged()
    {
        gm.audioManager.SetMixerLevel(eMixers.sound, sliders[(int)eMixers.sound].value, "soundVol");
    }

    */
    public void OnBackButton()
    {
        Destroy(this.gameObject);
    }
    
}
