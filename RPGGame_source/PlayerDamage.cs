using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public bool Trigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
            other.gameObject.GetComponent<GoblinHealthBar>().isAttacked(5f);
        }
        if (other.tag == "Enemy2")
        {
            other.gameObject.GetComponent<GoblinHealthBar3>().isAttacked(5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            
        }
    }
}
