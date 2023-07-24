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
        // Click to resume game and close pause menu
        gm.isPaused = false;
        gm.playerRef.GetComponent<PlayerBehavior>().enabled = true;
        Destroy(this.gameObject);
    }

    public void OnSettingsPressed()
    {
        // Click to open settings
        gm.canvasManager.ShowSettings();
    }

    public void OnMainMenuPressed()
    {
        // Click to go to the main menu
        gm.isPaused = false;
        gm.canvasManager.LoadLevel(eScene.mainMenu);
        Destroy(this.gameObject);
    }
}
