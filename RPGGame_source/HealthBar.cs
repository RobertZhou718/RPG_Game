using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider HPbar;
    public Animator anim;
    public float health;
    public GameObject text5;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
        health = 100f;
        text5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        HPbar.value = health;
        if (health <= 0)
        {
            anim.SetBool("die", true);
            text5.SetActive(false);
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
            {
                if (gameObject)
                {
                    
                    Destroy(gameObject);
                }
            }

        }
    }
    public void isAttacked(float damage)
    {
        
        health -= damage;
    }
}
