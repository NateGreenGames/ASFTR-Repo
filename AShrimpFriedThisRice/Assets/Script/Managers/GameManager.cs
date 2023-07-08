using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public PlayerBehavior playerRef;
    public soDish[] recipeList;


    private void Awake()
    {
        Init();
    }


    private void Init()
    {
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        if (!playerRef) playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();

    }


    public soDish SolveForRecipe(List<ItemSO> _presentIngredients)
    {
        for (int i = 0; i < recipeList.Length; i++)
        {
            for (int j = 0; j < recipeList[i].soItem.Count; j++)
            {
                if (!_presentIngredients.Contains(recipeList[i].soItem[j]))
                {
                    i++;
                    j = 0;
                }else if(j == recipeList[i].soItem.Count)
                {
                    return recipeList[i];
                }
            }
        }
        return null; //Return burnt food dish.

    }
}
