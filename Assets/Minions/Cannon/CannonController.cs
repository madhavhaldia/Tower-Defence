using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CannonController : MonoBehaviour
{

    Vector3 TargetLocation;
    public GameObject Target;
    public float Health;
    public float MaxHealth;
    TowerController towerController;
    bool FirstAttack;
    public float RateOfFire;
    float RoF;
    public float Force;
    public GameObject CannonBall;
    public GameObject Muzzle;
    NavMeshAgent Agent;
    public float DamageAmount;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        TargetLocation = Target.transform.position;
        towerController = GameObject.Find("EnemyTower").GetComponent<TowerController>();
        SetTarget(TargetLocation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetTarget(Vector3 TargetLocation)
    {
        
        Agent.destination = TargetLocation;
    }


    void TakeDamage(float Amount)
    {
        
        Health -= Amount;
 
        if (Health<=0)
        {
            Die();
        }
    }

    void AttackTimer()
    {
        this.transform.LookAt(Target.transform);
        if(Agent.velocity == new Vector3(0,0,0))
        {
            if (RoF <= 0)
            {
                RoF = RateOfFire;
                Fire();
            }
            else
            {
                RoF -= Time.deltaTime;
            }
        }
        

    }
    void Fire()
    {
        GameObject CannonBallInstance = Instantiate<GameObject>(CannonBall, Muzzle.transform.position, Muzzle.transform.rotation);
        CannonBallInstance.transform.LookAt(Target.transform);
        CannonBallInstance.GetComponent<Rigidbody>().AddForce(this.transform.forward * Force);
    }
        
    void Die()
    {
        towerController.Target = null;
        towerController.RateOfFire -= towerController.RateOfFireDefault;
        towerController.MinionData--;
        Destroy(this.gameObject);
    }

    void Combat(Collider collider)
    {
        if (collider.gameObject.layer == 9)
        {
            Destroy(collider.gameObject);
            TakeDamage(towerController.DamageAmount);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Combat(collider);
    }

    void OnTriggerStay(Collider collider)
    {
        AttackTimer();
    }
}
