using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCabinet : MonoBehaviour, IInteractable
{
    public GameObject heldItem;
    [SerializeField] Material previewMaterial;
    [SerializeField] Transform itemPositionAnchor;
    private GameObject spawnedGameObject;



    public bool isInteractable { get; set; }




    private Material[] initialMaterialList;
    private MeshRenderer m_MR;
    private GameManager gm;

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
        //If the player isn't carrying anything, and I have something;
        if (heldItem != null &&gm.playerRef.carriedObject == null)  //If the player isn't carrying anything, and I have something;
        {
            gm.playerRef.UpdatePlayerCarriedObject(heldItem);
            heldItem = null;
            Destroy(spawnedGameObject);
        }
        else if (heldItem == null && gm.playerRef.carriedObject != null) //If I have nothing, but player interacting with me has something;
        {
            heldItem = gm.playerRef.carriedObject;
            heldItem.transform.parent = itemPositionAnchor;
            heldItem.transform.position = itemPositionAnchor.position;
            gm.playerRef.UpdatePlayerCarriedObject(null);
        }
        else if(heldItem != null && gm.playerRef.carriedObject != null)
        {
            FoodInstance playerHeldItemFoodInstance = gm.playerRef.carriedObject.GetComponent<FoodInstance>();
            for (int i = 0; i < playerHeldItemFoodInstance.ingredientsPresent.Count; i++)
            {
                heldItem.GetComponent<FoodInstance>().ingredientsPresent.Add(playerHeldItemFoodInstance.ingredientsPresent[i]);
                heldItem.GetComponent<FoodInstance>().UpdateDisplayMesh();
            }
            Destroy(gm.playerRef.carriedObject);
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
