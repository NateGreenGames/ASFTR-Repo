using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodCabinetWorldCanvasUpdater : MonoBehaviour
{
    private Image m_Img;
    // Start is called before the first frame update
    void Start()
    {
        m_Img = gameObject.GetComponent<Image>();
        m_Img.sprite = transform.parent.parent.gameObject.GetComponent<FoodCabinet>().whatIStore.ItemIcon;
    }
}
