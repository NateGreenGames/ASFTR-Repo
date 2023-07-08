using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    
}
