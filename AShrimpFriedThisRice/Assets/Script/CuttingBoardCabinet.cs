using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardCabinet : MonoBehaviour, IInteractable
{
    public GameObject heldItem;
    [Range(0, 100)] public float progress;
    [SerializeField] Material previewMaterial;
    [SerializeField] Transform itemPositionAnchor;


    public bool isInteractable { get; set; }

    private Material[] initialMaterialList;
    private MeshRenderer m_MR;
    private GameManager gm;
    private GameObject spawnedGameObject;

    private void Start()
    {
        isInteractable = true;
        gm = GameManager.gm;
        m_MR = gameObject.GetComponent<MeshRenderer>();
        initialMaterialList = m_MR.materials;
    }

    private void Update()
    {
        if (gm.playerRef.whatImLookingAt != this.gameObject) OnHoverEnd(); //Turns off highlighting after the player looks away, stupid hack.
        if (heldItem != null && progress != 0) //If there's something in me, and I'm not cooking it, start cooking it.
        {

        }
        else if (heldItem == null)
        {
            progress = 0;
        }


    }

    public void OnInteract()
    {
        if (gm.playerRef.carriedObject == null && heldItem != null)  //If the player isn't carrying anything, and I have something;
        {
            gm.playerRef.UpdatePlayerCarriedObject(heldItem);
            heldItem = null;
            Destroy(spawnedGameObject);
        }
        else if (heldItem == null && gm.playerRef.carriedObject != null && gm.playerRef.carriedObject.GetComponent<FoodInstance>().ingredientsPresent.Count == 1) //If I have nothing, but player interacting with me has something;
        {
            heldItem = gm.playerRef.carriedObject;
            heldItem.transform.parent = itemPositionAnchor;
            heldItem.transform.position = itemPositionAnchor.position;
            gm.playerRef.UpdatePlayerCarriedObject(null);
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