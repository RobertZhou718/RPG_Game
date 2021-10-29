using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    public GameObject Lookatpoint;
    public GameObject Enemy;
    public Camera Main_camera;
    public Animator anim;
    public Ray ray;
    public bool move;
    public  bool idle;
    public float distance;
    public float walkspeed = 4f;
    public float runspeed = 8f;
    private float dis;
    private GameObject currentEnemy;
    private bool isDestination;
    public bool LongDisAtt = false;
    public bool fight = false;
    
    // Start is called before the first frame update
    void Start()
    {
       
        anim = GetComponent<Animator>();
        move = false;
        idle = true;
        Enemy = GameObject.FindWithTag("Enemy");
        isDestination = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Main_camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);// Shoot a ray from the camera to the mouse position
            RaycastHit[] raycasthit = Physics.RaycastAll(ray, 100);//collect these rays's info and the longest click distance is 50
            for (int i = 0; i < raycasthit.Length; i++)
            {
                if (raycasthit[i].collider.tag == "ground")
                {
                    Lookatpoint.transform.position = raycasthit[i].point;
                    this.transform.LookAt(Lookatpoint.transform.position);//let the character to look at the mouse click position
                    this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);//Make sure the character won't tilt downward
                    state_reset();
                    move = true;
                    isDestination = true;
                }
                if (raycasthit[i].collider.tag == "Enemy"|| raycasthit[i].collider.tag == "Enemy2")
                {
                    Lookatpoint.transform.position = raycasthit[i].point;
                    this.transform.LookAt(Lookatpoint.transform.position);
                    this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);//Make sure the character won't tilt downward
                    move = true;
                    distance = Vector3.Distance(transform.position, raycasthit[i].collider.transform.position);
                    currentEnemy = raycasthit[i].collider.gameObject;
                    isDestination = false;
                }
                if (LongDisAtt == false)//If the attack method is melee, attack when the distance with enemy is less than 3 
                {
                    if ((raycasthit[i].collider.tag == "Enemy" || raycasthit[i].collider.tag == "Enemy2") && distance < 3f)
                    {

                        move = false;
                        anim.SetBool("attack", true);

                    }
                }
                else
                {//If the attack method is range, attack when the distance with enemy is less than 25 
                    if ((raycasthit[i].collider.tag == "Enemy" || raycasthit[i].collider.tag == "Enemy2") && distance < 25f)
                    {
                        Debug.Log("123");
                        move = false;
                     
                        fight = true;

                    }
                    else {
                        fight = false;
                    }
                   
                }
                   
                
                if (raycasthit[i].collider.tag == "principal")
                {
                    isDestination = true;
                    Lookatpoint.transform.position = raycasthit[i].point;
                    this.transform.LookAt(Lookatpoint.transform.position);
                    this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);//Make sure the character won't tilt downward
                    move = true;
                    distance = Vector3.Distance(transform.position, raycasthit[i].collider.transform.position);  
                }
                if (raycasthit[i].collider.tag == "StudentCard")
                {
                    isDestination = true;
                    Lookatpoint.transform.position = raycasthit[i].point;
                    this.transform.LookAt(Lookatpoint.transform.position);
                    this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);//Make sure the character won't tilt downward
                    move = true;
                    distance = Vector3.Distance(transform.position, raycasthit[i].collider.transform.position);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (LongDisAtt == false)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {

                    anim.SetBool("attack", false);
                    anim.SetBool("idle", true);

                }
            }
      
        }

        if (isDestination)
        {
            dis = 0.1f;//Stop walking when the distance between the role position and the mouse click position is less than 0.1
        }
        else {
            dis = 3f;//if target is enemy, player will stop when the distance between the role position and the mouse click position is less than 3
        }
        if (move == true) {
            if (!isDestination) {
                Lookatpoint.transform.position = currentEnemy.transform.position;
            }
            if (Mathf.Abs(transform.position.x - Lookatpoint.transform.position.x) < dis && Mathf.Abs(transform.position.z - Lookatpoint.transform.position.z) < dis) {
                state_reset();
                idle = true;
                anim.SetBool("walk", false);
                anim.SetBool("run",false);
            }
            else {
                    anim.SetBool("walk", true);
                    moving(walkspeed);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetBool("run", true);
                    anim.SetBool("walk", false);
                    moving(runspeed);
                }
                else if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    anim.SetBool("walk", true);
                    anim.SetBool("run", false);
                    moving(walkspeed);
                }
            }//move 


           
        }
        if (Input.GetKeyDown(KeyCode.S))
            {
                if (LongDisAtt)
                {
                Debug.Log("Jin");
                    LongDisAtt = false;
                }
                else
                {
                Debug.Log("Yuan");
                LongDisAtt = true;
                }
         }
        

    }
    void state_reset()//reset the state
    {
        move = false;
        idle = false;
      

    }
    void moving(float speed)//move forward
    {
       transform.Translate(new Vector3(0, 0, speed * Time.deltaTime),Space.Self);

    }
   
}

