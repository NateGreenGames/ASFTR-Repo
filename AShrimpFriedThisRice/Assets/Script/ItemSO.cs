using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "New Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Mesh itemMesh;
    public Sprite ItemIcon;

    public ItemSO riceCookerOutput, cuttingOutput, friedOutput;

    public bool isChopped;
}
