using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_Item : MonoBehaviour
{
    public Image itemImg;

    public void WidgetItemInit(Sprite _itemImg)
    {
        itemImg.sprite = _itemImg;
    }
}
