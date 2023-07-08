using UnityEngine;
using System.Collections;

public class CanvasFE : MonoBehaviour
{
    public CanvasManager canvasManager;

    private GameManager gm;

    void Start()
    {
        gm = GameManager.gm;
        canvasManager = gm.gameObject.GetComponent<CanvasManager>();
    }

    public void OnQuitPressed()
    {
        
    }

    public void OnSettingsPressed()
    {

    }

    public void OnPlayPressed()
    {
        
    }

     

}
