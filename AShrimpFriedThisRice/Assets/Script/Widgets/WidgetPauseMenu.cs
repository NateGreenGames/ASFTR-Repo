using UnityEngine;

public class WidgetPauseMenu : MonoBehaviour
{
    // Buttons on the Pause Menu
    public void OnResumePressed()
    {
        Destroy(this.gameObject);
    }

    public void OnSettingsPressed()
    {
        GameManager.gm.canvasManager.ShowSettings();
    }

    public void OnMainMenuPressed()
    {
        GameManager.gm.canvasManager.LoadLevel(eScene.mainMenu);
        Destroy(this.gameObject);
    }
}
