using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    private CanvasFE canvasFE;

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

    public void ShowSettings()
    {
        Instantiate(Resources.Load("Canvas/CanvasSettings/" + "CanvasSettings") as GameObject).GetComponent<CanvasSettings>();
    }

    public void OnBackButtonPressed()
    {
        Destroy(this.gameObject);
    }
}
