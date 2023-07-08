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

    }

    public void OnPlayPressed()
    {
        gm.canvasManager.LoadLevel(eScene.level001);
    }

     

}
