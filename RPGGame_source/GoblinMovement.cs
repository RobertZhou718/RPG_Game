using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Animations;

public class GoblinMovement : MonoBehaviour
{
    public  Animator anim;
    public GameObject player;
    public  float distance;
    private float speed = 3.0f;
    private float runspeed = 6.0f;
    public float direction;
    public bool move1;
    public bool move2;
    public bool attack;
    public bool die;
    public bool idle;
    private float time = 5f;
    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

        
        distance = Vector3.Distance(transform.position, player.transform.position);//distance with player
        //Debug.Log(distance);
        if (distance > 50f)//the distance with player is more than 50, move randomly
        {

            StateRecover();
            if (time < 0) { 
              direction = Random.Range(0, 360f);
                transform.Rotate(0, direction,0);
               
                time = 2f;
        }
            time -= Time.deltaTime;
            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
            move1 = true;
        }else if (distance < 50f && distance > 35f)//the distance with player is more than 35 and less than 50, stand there and look at player
        {
            StateRecover();
            transform.LookAt(player.transform);
            transform.Translate(transform.forward * Time.deltaTime * 0, Space.World);
            idle = true;
        }else if (distance < 35f && distance > 15f)//the distance with player is more than 15 and less than 35, run to player
        {

            StateRecover();
            transform.LookAt(player.transform);
            transform.Translate(transform.forward * Time.deltaTime * runspeed, Space.World);
            move2 = true;
        } else if (distance < 15f && distance >  3f)//the distance with player is more than 3 and less than 15, walk to player's position
        {
            StateRecover();
            transform.LookAt(player.transform);
            transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
            move1 = true;
           
        }
        else if (distance < 3f)// the distance with player is less than 3, attack the player
        {
            StateRecover();
            attack = true;
        }


        if (idle) {
            anim.SetBool("idle",true);
           
        }
        if (move1) {
            anim.SetBool("walk", true);
            anim.SetBool("idle", false);
            anim.SetBool("attack", false);
            anim.SetBool("run", false);

        }
        if (move2) {
            anim.SetBool("walk", false);
            anim.SetBool("run", true);
            anim.SetBool("idle", false);

        }
        if (attack) {
           
            anim.SetBool("attack", true);
           
        }
        if (die) {
            anim.SetBool("die", true);
        }
    }
    void StateRecover() {
        idle = false;
        move1 = false;
        move2 = false;
        attack = false;
        die = false;
    }
}
