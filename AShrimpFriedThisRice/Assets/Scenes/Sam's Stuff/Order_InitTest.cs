using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order_InitTest : MonoBehaviour
{
    //public GameManager gm;
    //public Widget_Order widget_Order;
    public soDish soDish;

    private void Start()
    {
        //gm = GameManager.gm;
        Widget_Order widget_order = Instantiate(Resources.Load("Widgets/" + "Widget_Order") as GameObject, this.transform).GetComponent<Widget_Order>();
        widget_order.WidgetOrderInit(soDish, /*gm,*/ soDish.dishImg);
        //widget_Order = gameObject.AddComponent<Widget_Order>();
        //widget_Order.WidgetOrderInit(soDish, gm);
    }
}
