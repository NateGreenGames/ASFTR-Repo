using UnityEngine;

public class WidgetPauseMenu : MonoBehaviour
{
    private GameManager gm;
    private void Start()
    {
        gm = GameManager.gm;
    }
    // Buttons on the Pause Menu
    public void OnResumePressed()
    {
        gm.isPaused = false;
        gm.playerRef.GetComponent<PlayerBehavior>().enabled = true;
        Destroy(this.gameObject);
    }

    public void OnSettingsPressed()
    {
        gm.canvasManager.ShowSettings();
    }

    public void OnMainMenuPressed()
    {
        gm.isPaused = false;
        gm.canvasManager.LoadLevel(eScene.mainMenu);
        Destroy(this.gameObject);
    }
}
