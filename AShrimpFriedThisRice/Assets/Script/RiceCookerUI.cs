using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiceCookerUI : MonoBehaviour
{
    public enum ETableType {RiceCooker, CuttingBoard};


    public ETableType type;
    [SerializeField] GameObject slider;
    private Slider m_Slider;
    private BurnerCabinet cabinetRef;
    private CuttingBoardCabinet cuttingCabinet;
    // Start is called before the first frame update
    void Start()
    {
        m_Slider = slider.GetComponent<Slider>();
        if(type == ETableType.RiceCooker)
        {
            cabinetRef = transform.parent.gameObject.GetComponent<BurnerCabinet>();
        }
        else
        {
            cuttingCabinet = transform.parent.gameObject.GetComponent<CuttingBoardCabinet>();
        }
    }

    private void Update()
    {
        if (type == ETableType.RiceCooker)
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
        else
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
    }
}
