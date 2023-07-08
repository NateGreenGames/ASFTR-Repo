using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Dish")]
public class soDish : ScriptableObject
{
    public string dishName;
    public Sprite dishImg;
    public Mesh dishMesh;
    public List<ItemSO> soItem;
    
}
