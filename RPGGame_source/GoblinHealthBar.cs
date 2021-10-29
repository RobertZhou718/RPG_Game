using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinHealthBar : MonoBehaviour
{

    float x = 0f;
    float y = 200f;
    public RectTransform rec;
    public Slider healthbar;
    public Animator anim;
    public float health;
    public GameObject StudentCard;
    private bool dead = false;



    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
        health = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(transform.position);
        rec.position = player2DPosition + new Vector2(x,y);
        healthbar.value = health;
        if (health <= 0) {
            anim.SetBool("die",true);
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
            {
                if (gameObject)
                {
                    Destroy(gameObject);
                    GenerateGoblin.easyamount -= 1;
                    dead = true;
                }
            }
            if (dead)
            {
                GameObject obj = (GameObject)Instantiate(StudentCard);
                obj.transform.position = new Vector3(this.transform.position.x, 90, this.transform.position.z);
            }

        }

    }

    public void isAttacked(float damage)
    {
        //Debug.Log("was attacked");
        health -= damage;
    }
}
