using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDamage : MonoBehaviour
{

    float timeAlive = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > 1.5)
        {
            gameObject.SetActive(false);
            timeAlive = 0f;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<GoblinHealthBar>().isAttacked(10f);
        }
        if (other.tag == "Enemy2")
        {
            other.gameObject.GetComponent<GoblinHealthBar3>().isAttacked(10f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {

        }
    }
}
