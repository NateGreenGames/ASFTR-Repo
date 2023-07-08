using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiceCookerUI : MonoBehaviour
{

    [SerializeField] GameObject slider;
    private Slider m_Slider;
    private BurnerCabinet cabinetRef;
    // Start is called before the first frame update
    void Start()
    {
        m_Slider = slider.GetComponent<Slider>();
        cabinetRef = transform.parent.gameObject.GetComponent<BurnerCabinet>();
    }

    private void Update()
    {
        if(cabinetRef.cookingProgress == 0)
        {
            m_Slider.gameObject.SetActive(false);
        }
        else
        {
            m_Slider.gameObject.SetActive(true);
            m_Slider.value = cabinetRef.cookingProgress;
        }
        slider.transform.LookAt(slider.transform.position + new Vector3(0,-1,1));
    }
}
