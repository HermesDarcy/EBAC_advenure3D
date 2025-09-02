using AnimationsHD;
using BossEnemy;
using DG.Tweening;
using UnityEngine;

public class BossMove : BossBase
{

    public states newState;
    
    public float distanciaDeVisao = 15f;
    public float timePatrol = 5f;
    public float nextTimePatrol;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newState = state;
    }

    // Update is called once per frame
    void Update()
    {
        ListenerKeys();
        FaceTooPlayer();
        if (onMove)  BossOnMove();
        if(newState != state)
        {
            state = newState;
            bossStateMachine.SwithState(state, this);
        }
        ShootActions();
        if (nextTimePatrol < Time.time)
        {
            onMove = false;
        }


    }



    private void ShootActions()
    {
        // 1. Calcula a direção do player a partir da posição do inimigo
        Vector3 direcaoParaOPlayer = playerpos.position - transform.position;

        // 2. Dispara um raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direcaoParaOPlayer, out hit, distanciaDeVisao))
        {
            // 3. Verifica se o objeto atingido é o player
            if (hit.collider.CompareTag("Player") && !timeFire)
            {
                //Debug.Log("Player detectado!");
                // Adicione a lógica do inimigo aqui (ex: começar a perseguir o player)
                shoot();

            }

            // Opcional: Desenha uma linha para depuração na Scene View
            //Debug.DrawLine(transform.position, hit.point, Color.red);
        }

        if (Physics.Raycast(transform.position, direcaoParaOPlayer, out hit, distanciaDeVisao * 5f))
        {
            // 3. Verifica se o objeto atingido é o player
            if (hit.collider.CompareTag("Player"))
            {
                onMove = true;
                nextTimePatrol = Time.time + timePatrol;

            }

            
            //Debug.DrawLine(transform.position, hit.point, Color.yellow);

        }


    }



    #region Debug
    public void ListenerKeys()
    {
        if (Input.GetKeyDown(KeyCode.H)) // sendo atacado
        {
            
            bossStateMachine.SwithState(states.attack, this);
            OnDamage(2);
        }

        if (Input.GetKeyDown(KeyCode.J)) // idle
        {
            bossStateMachine.SwithState(states.idle, this);
        }

        if (Input.GetKeyDown(KeyCode.K)) // atacando
        {
            
            bossStateMachine.SwithState(states.attack, this);
            
        }

        if (Input.GetKeyDown(KeyCode.L)) // patrulha
        {
            bossStateMachine.SwithState(states.patrol, this);
        }

    }

    #endregion


}
