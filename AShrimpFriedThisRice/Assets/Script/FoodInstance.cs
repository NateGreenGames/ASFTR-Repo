using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInstance : MonoBehaviour
{
    public List<ItemSO> ingredientsPresent;


    private MeshFilter m_MF;

    private void Start()
    {
        m_MF = gameObject.GetComponent<MeshFilter>();
        UpdateDisplayMesh();
    }



    public void UpdateDisplayMesh()
    {
        if(ingredientsPresent.Count > 1)
        {
            if(GameManager.gm.SolveForRecipe(ingredientsPresent)?.dishMesh != null)
            {
                m_MF.mesh = GameManager.gm.SolveForRecipe(ingredientsPresent).dishMesh;
            }
        }
        else
        {
            m_MF.mesh = ingredientsPresent[0].itemMesh;
        }
    }
}
