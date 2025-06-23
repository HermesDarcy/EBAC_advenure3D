using Play.HD.StateMachines;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float forceJump =10f;
    public float speed=5f, vSpeed = 5f , jumpForce = 10f, speedRun =1.5f;
    
    public float rotSpeed = 10f;
    public float gravity = 9.8f;
    public float zonaMorta = 0.2f;
    public Animator playerAnim;
    private Rigidbody rb;
    public CharacterController charControl;
    public KeyCode keyRun=KeyCode.LeftShift;

    public enum states
    {
        Init,
        Attack,
        Run,
        Idle,
        Jump,
        Walk,
        WalkTras,
        RotLeft,
        RotRight,
        Death
    }

    public states onState;
    public StateMachine<states> posStateMachine = new StateMachine<states>();



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posStateMachine.Init();
        posStateMachine.RegisterStates(states.Init, new StateBase());
        posStateMachine.RegisterStates(states.Attack, new StatePlayerAttack());
        posStateMachine.RegisterStates(states.Idle, new StateBase());
        posStateMachine.RegisterStates(states.Run, new StateBase());
        posStateMachine.RegisterStates(states.Jump, new StatePlayerJump());
        posStateMachine.RegisterStates(states.Walk, new StateWalk());
        posStateMachine.RegisterStates(states.WalkTras, new StateWalkTras());
        posStateMachine.RegisterStates(states.RotLeft, new StateBase());
        posStateMachine.RegisterStates(states.RotRight, new StateBase());
        posStateMachine.RegisterStates(states.Death, new StateBase());


        //posStateMachine.SwithState(onState);
    }

    // Update is called once per frame
    void Update()
    {
        posStateMachine.SwithState(onState);
        moves();
    }




    private void moves()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime, 0); 
        var inputAxisVertical = Input.GetAxis("Vertical");
        //Debug.Log(inputAxisVertical);

        var speedVector = transform.forward * inputAxisVertical * speed;
        playerAnim.SetBool("Walk", inputAxisVertical > zonaMorta);
        playerAnim.SetBool("BackWalk", inputAxisVertical < -zonaMorta);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            vSpeed = jumpForce;
            onState = states.Jump;
        }
        
        
       
        
        
        if ( inputAxisVertical > zonaMorta)
        {
            if (Input.GetKey(keyRun))
            {
                playerAnim.speed = speedRun;
                speedVector *= speedRun;
                onState = states.Run;
            }
            else
            {
                onState = states.Walk;
                playerAnim.speed = 1;
            }
        }
        else
        {
            onState = states.Idle;
            playerAnim.speed = 1;
        }


        
        vSpeed -= gravity * Time.deltaTime;
        speedVector.y = vSpeed;
        charControl.Move(speedVector * Time.deltaTime);



        /*

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            onState = states.Jump;
            Debug.Log("Pulo Player");
        }
        
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            onState = states.Walk;
            transform.position += transform.forward * speed * Time.deltaTime;
            playerAnim.SetTrigger("Walk");
            
            Debug.Log("walk Player");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            onState = states.RotLeft;
            playerAnim.SetTrigger("Idle");
            transform.Rotate(Vector3.up, -rotSpeed * Time.deltaTime);
            Debug.Log("left rotate  Player");

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            onState = states.RotRight;
            playerAnim.SetTrigger("Idle");
            transform.Rotate(Vector3.up, +rotSpeed * Time.deltaTime);
            Debug.Log("right rotate Player");
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            onState = states.WalkTras;
            playerAnim.SetTrigger("BackWalk");
            transform.position -= transform.forward * speed * 0.8f * Time.deltaTime;
        }
        else
        {
            //onState = states.Idle;
            playerAnim.SetTrigger("Idle");

        }
        */

    }

}
