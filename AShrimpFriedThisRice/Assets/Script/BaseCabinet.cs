using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCabinet : MonoBehaviour, IInteractable
{
    public ItemSO heldItem;
    public bool isInteractable { get; set; }
    public Material previewMaterial;

    private Material[] initialMaterialList;
    private MeshRenderer m_MR;

    private void Start()
    {
        m_MR = gameObject.GetComponent<MeshRenderer>();
        initialMaterialList = m_MR.materials;
    }

    private void Update()
    {
        
    }
    public void OnInteract()
    {

    }

    public void OnHover()
    {
        Material[] newMatList = new Material[initialMaterialList.Length];
        for (int i = 0; i < initialMaterialList.Length; i++)
        {
            newMatList[i] = previewMaterial;
        }

        m_MR.materials = newMatList;
    }

    public void OnHoverEnd()
    {
    }

}
