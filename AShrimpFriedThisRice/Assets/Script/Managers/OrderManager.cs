using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public GameManager gm;
    public bool startGettingOrders;
    //public soDish soDish;

    private void Start()
    {
        if (startGettingOrders == false)
        {
            return;
        }
        gm = GameManager.gm;
        StartCoroutine(OrderDelay());
    }

    public void OrderManagerInit()
    {
        soDish _soDish = gm.recipeList[Random.Range(0, gm.recipeList.Length)];

        Widget_Order widget_order = Instantiate(Resources.Load("Widgets/" + "Widget_Order") as GameObject, this.transform).GetComponent<Widget_Order>();
        widget_order.WidgetOrderInit(_soDish, _soDish.dishImg);
    }

    public IEnumerator OrderDelay()
    {
        OrderManagerInit();
        yield return new WaitForSeconds(10);
        StartCoroutine(OrderDelay());
    }
}
