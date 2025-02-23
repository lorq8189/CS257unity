using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    // Start is called before the first frame update
    public enum EnemyState {GoToBase, AttackBase, ChasePlayer, AttackPlayer}

    public EnemyState currentState;
    public float baseAttackDistance;
    
    public float playerAttackDistance;

    public Sight sightSensor;


    private Transform baseTransform;

    private UnityEngine.AI.NavMeshAgent agent;

    public GameObject bulletPrefab;
    public float lastShootTime;
    public float firerate;





    void GoToBase()
    {
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        
        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }

        float dtBase = Vector3.Distance(transform.position, baseTransform.position);

        if (dtBase < baseAttackDistance)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    void AttackBase()
    {
        agent.isStopped = true;
        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();
    } 

    void ChasePlayer()
    {
        agent.isStopped = false;

        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        float dtPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (dtPlayer < playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }

        agent.SetDestination(sightSensor.detectedObject.transform.position);

    }  


    void AttackPlayer()
    {
        agent.isStopped = true;

        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }

        LookTo(sightSensor.detectedObject.transform.position);
        Shoot();

        float dtPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if (dtPlayer > 1.1 * playerAttackDistance)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }


    void Shoot()
    {
        var elapsed = Time.time - lastShootTime;
        if (elapsed > firerate)
        {
            lastShootTime = Time.time;
            Instantiate (bulletPrefab, transform.position, transform.rotation);


        }

    }


    void LookTo(Vector3 target)
    {
        Vector3 dtPos = Vector3.Normalize(target - transform.parent.position);
        dtPos.y = 0;
        transform.parent.forward = dtPos;
    }
    
    
    void Awake()
    {
        baseTransform = GameObject.Find("BaseDamagePoint").transform;


        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
    }



    // Update is called once per frame
    void Update()
    {
        if (currentState == EnemyState.GoToBase)
        {
            GoToBase();
        }
        else if 
        (currentState == EnemyState.AttackBase)
        {
            AttackBase();
        }
        else if 
        (currentState == EnemyState.ChasePlayer)
        {
            ChasePlayer();
        }
        else 
        {
            AttackPlayer();
        }
    }
}
