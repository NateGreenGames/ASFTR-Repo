using UnityEngine;
using System.Collections;

public class CanvasFE : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = GameManager.gm;
    }

    public void OnQuitPressed()
    {
        
    }

    public void OnSettingsPressed()
    {
        gm.canvasManager.ShowSettings();
    }

    public void OnPlayPressed()
    {
        // Temporily Natetest Scene instead of level one for testing purposes
        gm.canvasManager.LoadLevel(eScene.nateTestScene);
    }

     

}
