using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "New Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public GameObject ItemObject;
    public Sprite ItemIcon;


    public ItemSO riceCookerOutput, cuttingOuput, friedOutput;
}
