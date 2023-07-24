using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardCabinet : MonoBehaviour, IInteractable
{
    public GameObject heldItem;
    [Range(0, 100)] public float progress;
    [SerializeField] Material previewMaterial;
    [SerializeField] Transform itemPositionAnchor;

    private bool isEngaging = false;
    private bool isHovering;

    public bool isInteractable { get; set; }

    private Material[] initialMaterialList;
    private MeshRenderer m_MR;
    private GameManager gm;
    private GameObject spawnedGameObject;


    private float timeToCut = 3;
    private float timerHolder;

    private void Start()
    {
        isInteractable = true;
        gm = GameManager.gm;
        m_MR = gameObject.GetComponent<MeshRenderer>();
        initialMaterialList = m_MR.materials;
    }

    private void Update()
    {
        // Checks to see if the item is chopped. If true, press space does nothing.
        if (Input.GetKey(KeyCode.Space) && heldItem != null && isHovering && heldItem.GetComponent<FoodInstance>().ingredientsPresent[0].isChopped == false) 
        {
            isEngaging = true;
            if(timerHolder < timeToCut)
            {
                timerHolder += Time.deltaTime;
                progress = Mathf.Lerp(0, 1, Mathf.InverseLerp(0, timeToCut, timerHolder));
            }
            else if(timerHolder >= timeToCut)
            {
                FoodInstance foodRef = heldItem.GetComponent<FoodInstance>();
                foodRef.ingredientsPresent[0] = foodRef.ingredientsPresent[0].cuttingOutput;
                foodRef.UpdateDisplayMesh();
                timerHolder = 0;
            }
        }
        else
        {
            isEngaging = false;
            // timerHolder = 0;
        }
        if (gm.playerRef.whatImLookingAt != this.gameObject) OnHoverEnd(); //Turns off highlighting after the player looks away, stupid hack.
        if (heldItem == null)
        {
            progress = 0;
        }
    }

    public void OnInteract()
    {
        if (gm.playerRef.carriedObject == null && heldItem != null)  //If the player isn't carrying anything, and I have something;
        {
            isEngaging = true;
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
            timerHolder = 0;
        }
    }

    public void OnHover()
    {
        Material[] newMatList = new Material[initialMaterialList.Length];
        for (int i = 0; i < initialMaterialList.Length; i++)
        {
            newMatList[i] = previewMaterial;
        }
        isHovering = true;
        m_MR.materials = newMatList;
    }

    public void OnHoverEnd()
    {
        isHovering = false;
        m_MR.materials = initialMaterialList;

    }

}
