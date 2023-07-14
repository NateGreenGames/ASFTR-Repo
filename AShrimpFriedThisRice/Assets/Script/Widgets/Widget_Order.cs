using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Widget_Order : MonoBehaviour
{
    public soDish sODish;
    public Image dishImg;
    public Transform grid_Grp;
    public TextMeshProUGUI orderName;

    public Slider timerBar;
    public float currentTimer = 40;
    //public int startingTime = ;
    //public GameManager gm;

    public void WidgetOrderInit(soDish _soDish/*, GameManager _gm*/, Sprite _dishImg)
    {
        sODish = _soDish;
        //gm = _gm;
        dishImg.sprite = _dishImg;
        orderName.text = sODish.dishName;
        //currentTimer = startingTime;
        timerBar.maxValue = currentTimer;
        GenerateOrderWidget();
        StartCoroutine(StartOrderTimer());
    }

    public IEnumerator StartOrderTimer()
    {
        while (currentTimer > 0)
        {
            currentTimer -= 1 * Time.deltaTime;
            timerBar.value = currentTimer;
            yield return "success";
        }
        Debug.Log("Error LOL");
        yield return null;
    }


    public void GenerateOrderWidget()
    {
        for (int i = 0; i < sODish.soItem.Count; i++)
        {
            Widget_Item widget_Item = Instantiate(Resources.Load("Widgets/" + "Widget_Item") as GameObject, grid_Grp.transform).GetComponent<Widget_Item>();
            widget_Item.WidgetItemInit(sODish.soItem[i].ItemIcon);
        }
    }
}
