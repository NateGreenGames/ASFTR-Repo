using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInstance : MonoBehaviour
{
    public List<ItemSO> ingredientsPresent;


    private MeshFilter m_MF;




    public void UpdateDisplayMesh()
    {
        m_MF.mesh = GameManager.gm.SolveForRecipe(ingredientsPresent).dishMesh;
    }
}
