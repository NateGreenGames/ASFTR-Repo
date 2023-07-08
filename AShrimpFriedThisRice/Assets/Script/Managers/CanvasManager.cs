using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    private CanvasFE canvasFE;

    // Functions used to change scenes

    private void Start()
    {
        

    }
    public void ShowCanvasFE()
    {
        Instantiate(Resources.Load("Canvas/CanvasFE/" + "CanvasFE") as GameObject).GetComponent<CanvasFE>();
    }
    
    public void LoadLevel(eScene _scene)
    {
        SceneManager.LoadScene((int)_scene);
    }
    
}
