using UnityEngine;
using System.Collections;



public class CanvasFE : MonoBehaviour
{
    IEnumerator WaitUntilSoundPlayed(GameObject _go)
    {
        yield return new WaitForSeconds(1);
        Destroy(_go);
    }

    GameManager gm;
    public CanvasManager canvasManager;
    void Start()
    {
        gm = GameManager.gm;
    }

    public void OnPlayNowPressed()
    {
        // TODO: Need Setup Screen and canvasManager
        
       // gm.canvasManager.ShowSetupScreen();
        
    }

    public void OnOptionsPressed()
    {
       // gm.canvasManager.ShowCanvasOptions();
    }

    public void OnButtonPressed()
    {
        WaitUntilSoundPlayed(this.gameObject);
    }

     

}
