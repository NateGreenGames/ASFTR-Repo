using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerCabinet : MonoBehaviour, IInteractable
{
    public GameObject heldItem;
    [Range(0, 100)] public float cookingProgress;
    [SerializeField] Material previewMaterial;
    [SerializeField] Transform itemPositionAnchor;
    [SerializeField] GameObject fireEffect;

    [SerializeField] private float cookTime;


    public bool isInteractable { get; set; }

    private bool isCooking;
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
        if (!isCooking && heldItem != null) //If there's something in me, and I'm not cooking it, start cooking it.
        {
            StartCoroutine(CookingRoutine());
        }
        else if(isCooking && heldItem == null)
        {
            StopAllCoroutines();
            fireEffect.SetActive(false);
            isCooking = false;
            cookingProgress = 0;
        }
    }

    private IEnumerator CookingRoutine()
    {
        FoodInstance foodRef = heldItem.GetComponent<FoodInstance>();
        fireEffect.SetActive(true);
        isCooking = true;
        float elapsedTime = 0;
        while (elapsedTime < cookTime)
        {
            cookingProgress = Mathf.Lerp(0, 1, Mathf.InverseLerp(0, cookTime, elapsedTime));
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
        }
        foodRef.ingredientsPresent[0] = foodRef.ingredientsPresent[0].friedOutput;
        foodRef.UpdateDisplayMesh();
        fireEffect.SetActive(false);
        isCooking = false;
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
