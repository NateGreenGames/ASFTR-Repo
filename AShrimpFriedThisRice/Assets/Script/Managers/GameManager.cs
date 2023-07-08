using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public PlayerBehavior playerRef;



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
}
