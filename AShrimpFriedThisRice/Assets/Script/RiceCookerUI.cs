using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiceCookerUI : MonoBehaviour
{
    public enum ETableType { Stove, CuttingBoard, RiceCooker};


    public ETableType type;
    [SerializeField] GameObject slider;
    private Slider m_Slider;
    private BurnerCabinet cabinetRef;
    private RiceCookerCabinet riceCookerCabinet;
    private CuttingBoardCabinet cuttingCabinet;
    // Start is called before the first frame update
    void Start()
    {
        m_Slider = slider.GetComponent<Slider>();
        if(type == ETableType.Stove)
        {
            cabinetRef = transform.parent.gameObject.GetComponent<BurnerCabinet>();
        }
        else if (type == ETableType.CuttingBoard)
        {
            cuttingCabinet = transform.parent.gameObject.GetComponent<CuttingBoardCabinet>();
        }
        else if (type == ETableType.RiceCooker)
        {
            riceCookerCabinet = transform.parent.gameObject.GetComponent<RiceCookerCabinet>();
        }
    }

    private void Update()
    {
        // Checks what type of table the player is looking at and updates the progress bar respectively 
        if (type == ETableType.Stove)
        {
            if (cabinetRef.cookingProgress == 0)
            {
                m_Slider.gameObject.SetActive(false);
            }
            else
            {
                m_Slider.gameObject.SetActive(true);
                m_Slider.value = cabinetRef.cookingProgress;
            }
            slider.transform.LookAt(slider.transform.position + new Vector3(0, -1, 1));
        }
        else if (type == ETableType.CuttingBoard)
        {
            if (cuttingCabinet.progress == 0)
            {
                m_Slider.gameObject.SetActive(false);
            }
            else
            {
                m_Slider.gameObject.SetActive(true);
                m_Slider.value = cuttingCabinet.progress;
            }
            slider.transform.LookAt(slider.transform.position + new Vector3(0, -1, 1));
        }
        else if (type == ETableType.RiceCooker)
        {
            if (riceCookerCabinet.cookingProgress == 0)
            {
                m_Slider.gameObject.SetActive(false);
            }
            else
            {
                m_Slider.gameObject.SetActive(true);
                m_Slider.value = riceCookerCabinet.cookingProgress;
            }
            slider.transform.LookAt(slider.transform.position + new Vector3(0, -1, 1));
        }
    }
}
