using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCabinet : MonoBehaviour, IInteractable
{
    public ItemSO whatIStore;
    public Material previewMaterial;
    public bool isInteractable { get; set; }
    private Material[] initialMaterialList;
    private MeshRenderer m_MR;
    private GameManager gm;


    private void Awake()
    {
        //Set the icon on the cabinet;

    }
    private void Start()
    {
        isInteractable = true;
        gm = GameManager.gm;
        m_MR = gameObject.GetComponent<MeshRenderer>();
        initialMaterialList = m_MR.materials;
    }

    private void Update()
    {
        if (gm.playerRef.whatImLookingAt != this.gameObject) OnHoverEnd();
    }
    public void OnInteract()
    {
        if (whatIStore != null && gm.playerRef.carriedObject == null)
        {
            gm.playerRef.SpawnNewPlayerCarriedObject(whatIStore);
        }
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
        m_MR.materials = initialMaterialList;
    }
}
