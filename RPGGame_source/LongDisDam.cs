using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDisDam : MonoBehaviour
{
    public GameObject player;
    public GameObject shockwave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (player.GetComponent<PlayerMovement>().LongDisAtt == true && player.GetComponent<PlayerMovement>().fight == true) {
          
            if (Input.GetMouseButtonDown(0)) {
             
                shoot();  
            }
        }
    }

    void shoot() {
        GameObject obj = (GameObject)Instantiate(shockwave);
        obj.transform.position = transform.position + transform.forward + transform.up ;
        obj.GetComponent<Rigidbody>().velocity = transform.forward * 50;
        obj.SetActive(true);
    }
  
}
