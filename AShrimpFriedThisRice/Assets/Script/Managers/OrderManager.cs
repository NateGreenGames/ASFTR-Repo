using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public GameManager gm;
    //public soDish[] soDishes;
    public List<soDish> orders = new List<soDish>();
    public int currentOrders;
    public int maxOrders = 5;
    public bool startGettingOrders;
    //public soDish soDish;

    public void Init()
    {
        //Debug.Log(GameManager.gm.canvasManager.canvasInGame.orders_grp.transform);
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
        orders.Add(_soDish);

        Widget_Order widget_order = Instantiate(Resources.Load("Widgets/" + "Widget_Order") as GameObject, gm.canvasManager.canvasInGame.orders_grp.transform).GetComponent<Widget_Order>();
        widget_order.WidgetOrderInit(_soDish, _soDish.dishImg);
        currentOrders += 1;
    }

    public IEnumerator OrderDelay()
    {
        while (currentOrders >= maxOrders)
        {
            Debug.Log("waiting 10");
            yield return new WaitForSeconds(10);
            yield return null;
        }
        OrderManagerInit();
        yield return new WaitForSeconds(12);
        StartCoroutine(OrderDelay());
    }
}
