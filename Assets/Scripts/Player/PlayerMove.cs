using DG.Tweening;
using Enemy_Alien;
using Play.HD.StateMachines;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour , IDamagem
{
    
    public int lives, initLives;
    public int checkPoint;
    [HideInInspector]
    public Transform checkPointPos;
    public float forceJump =10f;
    public float speed=5f, vSpeed = 5f , jumpForce = 10f, speedRun =2f;
    public List<FlashColors> flashColors = new List<FlashColors>();
    public float rotSpeed = 10f;
    public float gravity = 9.8f;
    public float zonaMorta = 0.2f;
    public Animator playerAnim;
    public CharacterController charControl;
    public List<Collider> colliders = new List<Collider>();
    public KeyCode keyRun=KeyCode.LeftShift;
    public UI_updates uI_Updates;
    private bool nonDeath = true;
    private bool onPause = false;
    private Rigidbody rb;

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
    //public StateMachine<states> posStateMachine = new StateMachine<states>();



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        checkPointPos = transform;
        /*
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
        */

        //posStateMachine.SwithState(onState);
    }

    // Update is called once per frame
    void Update()
    {
        //posStateMachine.SwithState(onState, this);
        
        if(lives <= 0 && nonDeath == true)
        {
            //this.gameObject.SetActive(false);
            playerAnim.SetTrigger("Death");
            colliders.ForEach(i => i.enabled = false);
            nonDeath = false;
            Invoke("ResSpaw", 5f);

            //onState = states.Death;
        }
        else if(nonDeath == true && onPause == false) 
        {
            moves();
        }
    }

    [NaughtyAttributes.Button]
    public void PausePlayer()
    {
        StartCoroutine(ToTimePause());
    }

    IEnumerator ToTimePause()
    {
        onState = states.Idle;
        onPause = true;
        playerAnim.SetTrigger("Idle");
        yield return new WaitForSeconds(3f);
        onPause = !onPause;
    }




    private void moves()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime, 0); 
        var inputAxisVertical = Input.GetAxis("Vertical");
        //Debug.Log(inputAxisVertical);

        var speedVector = transform.forward * inputAxisVertical * speed;
        playerAnim.SetBool("Walk", inputAxisVertical > zonaMorta);
        playerAnim.SetBool("BackWalk", inputAxisVertical < -zonaMorta);


        vSpeed -= gravity * Time.deltaTime;


        if (charControl.isGrounded)
        {
            vSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vSpeed = jumpForce;
                onState = states.Jump;
            }

        }

        
        speedVector.y = vSpeed;
        charControl.Move(speedVector * Time.deltaTime);

        


        if ( inputAxisVertical > zonaMorta  )
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


    private void OnCollisionEnter(Collision collision)
    {
        EnemyBase enemyBase = collision.gameObject.GetComponent<EnemyBase>();
        if (enemyBase != null)
        {
            
            Damage(1);
            

        }
    }
    

    public void Damage(int damage)
    {
        flashColors.ForEach(i => i.OnDamageFlash());
        PostProcessingManager.Instance.flashVignette();
        ShekeCamera.Instance.OnShakeCam(5f,5f,.3f);
        lives -= damage;
        uI_Updates.ValueLife(initLives, lives);
        PostProcessingManager.Instance.DownSaturation();
    }

    public void Damage(int d, Vector3 dir)
    {
        //OnDamage(d);
        //Debug.Log("player damage");
        PostProcessingManager.Instance.flashVignette();
        ShekeCamera.Instance.OnShakeCam(5f,5f,.6f);
        transform.DOMove(transform.position - dir , .2f);
        flashColors.ForEach(i => i.OnDamageFlash());
        lives -= d;
        uI_Updates.ValueLife(initLives, lives);
        PostProcessingManager.Instance.DownSaturation();
    }


    [NaughtyAttributes.Button]
    private void ResSpaw()
    {
        nonDeath = false;
        transform.position = checkPointPos.position;
        playerAnim.SetTrigger("Idle");
        
        lives = initLives;
        onState = states.Idle;
        playerAnim.speed = 1;
        uI_Updates.ValueLife(initLives, lives);
        PostProcessingManager.Instance.resetSaturation();
        Invoke("onAlive", 1f);

    }


    private void onAlive()
    {
        colliders.ForEach(i => i.enabled = true);
        nonDeath = true;
    }



}
