using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLive : MonoBehaviour
{
    public int healt = 100;
    public Animator anim;
    public Sprite[] heart;
    public Image[] heartUi;
    public int lives = 3;
     public Text tex = null;

    public void Start()
    {
        for(int i = 0; i< heartUi.Length; i++)
        {
            heartUi[i].sprite = heart[0];
        }
        tex = GameObject.Find("TX").GetComponent<Text>();
    }

    public void TakeDamage(int damage)
    {
        healt -= damage;
       
            print("AUSHHHH");
            anim.SetTrigger("Down");
       if (lives > 1)
        {
            lives -= 1;
            heartUi[lives].color = Color.black;
            print("alsfhajksf");
        }
        else 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameMaster.countEnemy = 0;
        }

    }


    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;

        while(knockDur > timer)
        {
            timer += Time.deltaTime;
            GetComponent<Rigidbody2D>().AddForce(new Vector3(knockbackDir.x * 50 ,knockbackDir.y * -100 , transform.position.z));
            yield return new WaitForSeconds(0.2f);
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameMaster.countEnemy = 0;
        }

        yield return 0;
    }



    private void Update()
    {
        if(healt <= 0)
        {

        }
        tex.text = "Numero enemigos " + GameMaster.countEnemy;
    }
}
