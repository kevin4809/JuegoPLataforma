using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    private static GameMaster instance;
    public Vector2 lastChekPointPos;
    public static float countEnemy;
    public float a;
     Transform sb;
     Transform s1;
     Transform s2;
     Transform s3;
    public GameObject boss;
    public GameObject E1;
    public GameObject E2;
    public GameObject E3;

    private void Start()
    {
        sb = GameObject.Find("SB").GetComponent<Transform>();
        s1 = GameObject.Find("P1").GetComponent<Transform>();
        s2 = GameObject.Find("P2").GetComponent<Transform>();
        s3 = GameObject.Find("P3").GetComponent<Transform>();
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(countEnemy == 0)
        {
            Instantiate(boss);
            boss.transform.position = sb.transform.position;

            Instantiate(E1);
            E1.transform.position = s1.transform.position;

            Instantiate(E2);
            E2.transform.position = s2.transform.position;

            Instantiate(E3);
            E3.transform.position = s3.transform.position;
        }
        a = countEnemy;

       
    }


}
