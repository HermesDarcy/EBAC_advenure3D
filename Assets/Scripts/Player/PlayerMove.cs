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
    
    public float lives, initLives, multiplyDamage =1f;
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
    private bool shield = false;
    private bool isJump = false;
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
        yield return new WaitForSeconds(1f);
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

            if (isJump) // true
            {
                isJump = false;
                playerAnim.SetTrigger("Land");
            }
            
            vSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                
                vSpeed = jumpForce;
                
                if(!isJump) // false
                {
                    
                    playerAnim.SetTrigger("Jump");
                    onState = states.Jump;
                    isJump = true;
                }
                
               
            }

        }

        
        

        


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


    private void OnCollisionEnter(Collision collision)
    {
        EnemyBase enemyBase = collision.gameObject.GetComponent<EnemyBase>();
        if (enemyBase != null && shield == false)
        {
            
            Damage(1);
        }

        if(collision.gameObject.CompareTag("shield"))
        { 
            collision.gameObject.SetActive(false);
            shield = true;
            uI_Updates.shieldOn();
            
            Invoke("toblink", 10f);
            Invoke("TimeShield", 16f);
            Debug.Log("ON shield");
        }




    }
    
    

    private void toblink()
    {
        uI_Updates.blinkImage();
        Debug.Log("piscando shield");
    }



    private void TimeShield()
    {
        shield = false;
        uI_Updates.shieldOff();
        
        Debug.Log("end shield");
    }



    public void Damage(int damage)
    {
        if (shield == false)
        {
            flashColors.ForEach(i => i.OnDamageFlash());
            PostProcessingManager.Instance.flashVignette();
            ShekeCamera.Instance.OnShakeCam(5f, 5f, .3f);
            lives -= damage * multiplyDamage;
            uI_Updates.ValueLife(initLives, lives);
            PostProcessingManager.Instance.DownSaturation();
        }
    }

    public void Damage(int d, Vector3 dir)
    {

        if (shield == false)
        {
            //OnDamage(d);
            //Debug.Log("player damage");
            PostProcessingManager.Instance.flashVignette();
            ShekeCamera.Instance.OnShakeCam(5f, 5f, .6f);
            transform.DOMove(transform.position - dir, .2f);
            flashColors.ForEach(i => i.OnDamageFlash());
            lives -= d * multiplyDamage;
            uI_Updates.ValueLife(initLives, lives);
            PostProcessingManager.Instance.DownSaturation();
        }
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


    public void addlife(int x)
    {
        lives += x;
    }

    public void ResetLifes()
    {
        lives = initLives;
        uI_Updates.ValueLife(initLives, lives);
        PostProcessingManager.Instance.resetSaturation();
    }


    public void NewSpeed(float speed, float duration)
    {
        StartCoroutine(TimeToSpeed(speed, duration));
        Debug.Log("new speed");
    }

    IEnumerator TimeToSpeed(float newSpeed, float duration)
    {
        float stdSpeed = speed;
        speed *= newSpeed;
        yield return new WaitForSeconds(duration);
        speed = stdSpeed;
    }


    public void StrongForce(float force, float duration)
    {
        StartCoroutine(TimeToStrong(force, duration));
    }

    IEnumerator TimeToStrong(float force, float duration)
    {
        multiplyDamage = force;
        yield return new WaitForSeconds(duration);
        multiplyDamage = 1f;
    }


}
