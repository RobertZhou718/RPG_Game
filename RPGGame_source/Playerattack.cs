using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack : MonoBehaviour
{
    public bool trigger;
    public Ray ray;
    public Camera main_camera;
    public Animator anim;
    public GameObject point;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            ray = main_camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit raycasthit;
            if (Physics.Raycast(ray, out raycasthit, 100f)){

                Debug.Log(raycasthit.collider.tag);
                if (raycasthit.collider.tag == "Enemy")
                {
                    point.transform.position = raycasthit.point;
                    this.transform.LookAt(point.transform);
                    anim.SetBool("attack", true);
                }
                else {
                    anim.SetBool("attack", false);
                }
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
            trigger = true;
        
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            trigger = false;

        }
    }
}
