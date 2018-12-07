using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    private static GameMaster instance;
    public Vector2 lastChekPointPos;

    
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
         //  DontDestroyOnLoad(instance);

        }
        else
        {
            Destroy(gameObject);
        }

    
    }

}

