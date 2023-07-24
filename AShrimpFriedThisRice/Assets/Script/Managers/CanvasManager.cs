using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    private CanvasFE canvasFE;
    public CanvasInGame canvasInGame;

    // Function used to change scenes
    public void LoadLevel(eScene _scene)
    {
        SceneManager.LoadScene((int)_scene);
    }

    // Functions used to load canvases
    public void ShowCanvasFE()
    {
        Instantiate(Resources.Load("Canvas/CanvasFE/" + "CanvasFE") as GameObject).GetComponent<CanvasFE>();
    }

    // UI while in game
    public void ShowCanvasInGame()
    {
        canvasInGame = Instantiate(Resources.Load("Canvas/" + "Canvas_InGame") as GameObject).GetComponent<CanvasInGame>();
    }
    
    // Function used to call settings menu
    public void ShowSettings()
    {
        Instantiate(Resources.Load("Canvas/CanvasSettings/" + "CanvasSettings") as GameObject).GetComponent<CanvasSettings>();
    }

    // Function used for back button
    public void OnBackButtonPressed()
    {
        Destroy(this.gameObject);
    }

    // Used to bring up pause menu
    public void ShowPauseMenu()
    {
        Instantiate(Resources.Load("Widgets/" + "Widget_PauseMenu") as GameObject).GetComponent<WidgetPauseMenu>();
        GameManager.gm.playerRef.GetComponent<PlayerBehavior>().enabled = false;
    }
}
