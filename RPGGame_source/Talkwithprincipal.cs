using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkwithprincipal : MonoBehaviour
{
    public GameObject Principal;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public  bool trigger;
    
  
    // Start is called before the first frame update
    void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        text4.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {

            text1.SetActive(false);
            text2.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (PickCard.CardNum < 15)
        {
            if (other.tag == "principal")
            {
                trigger = true;
                Principal = other.gameObject;
                text1.SetActive(true);
                text4.SetActive(false);
            }
        }
        else {
            text3.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "principal")
        {
            trigger = false;
            Principal = null;
            text2.SetActive(false);
            text1.SetActive(false);


        }
    }
}
