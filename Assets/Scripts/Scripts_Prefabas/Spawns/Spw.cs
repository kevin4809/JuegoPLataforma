using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spw : MonoBehaviour {
    [SerializeField]
    public static float countEnemy;
    Transform sb;
    Transform s1;
    Transform s2;
    Transform s3;
    public GameObject boss;
    public GameObject E1;
    public GameObject E2;
    public GameObject E3;

    public float a;
    private void Start()
    {
        sb = GameObject.Find("SB").GetComponent<Transform>();
        s1 = GameObject.Find("P1").GetComponent<Transform>();
        s2 = GameObject.Find("P2").GetComponent<Transform>();
        s3 = GameObject.Find("P3").GetComponent<Transform>();
    }

    private void Update()
    {
        if (countEnemy == 0)
        {
            Instantiate(boss);
            boss.transform.position = sb.transform.position;
            Spw.countEnemy = 0;

            Instantiate(E1);
            E1.transform.position = s1.transform.position;
            Spw.countEnemy = 0;
            Instantiate(E2);
            E2.transform.position = s2.transform.position;
            Spw.countEnemy = 0;
            Instantiate(E3);
            E3.transform.position = s3.transform.position;
            Spw.countEnemy = 0;

        }
        a = countEnemy;

        if(countEnemy > 10)
        {
            countEnemy = 10;
        }


    }
}
