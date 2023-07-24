using UnityEngine;
using System.Collections;

public class CanvasFE : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = GameManager.gm;
    }

    // Quits the game
    public void OnQuitPressed()
    {
        // TODO: Button needs to close game
    }
    
    // Takes player to settings menu
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
