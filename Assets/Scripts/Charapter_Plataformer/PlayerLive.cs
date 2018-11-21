using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLive : MonoBehaviour
{
    public int healt = 100;
    public Animator anim;
         
   

    public void TakeDamage(int damage)
    {
        healt -= damage;
       
            print("AUSHHHH");
            anim.SetTrigger("Down");

    }


    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;

        while(knockDur > timer)
        {
            timer += Time.deltaTime;
            GetComponent<Rigidbody2D>().AddForce(new Vector3(knockbackDir.x * 50 ,knockbackDir.y * -100 , transform.position.z));
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene("Plataformero");
        }

        yield return 0;
    }



    private void Update()
    {
        if(healt <= 0)
        {

        }
    }
}
