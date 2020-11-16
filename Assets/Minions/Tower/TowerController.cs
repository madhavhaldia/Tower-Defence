using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public float Health;
    public float MaxHealth;
    public GameObject Muzzle;
    public GameObject CannonBall;
    public GameObject Cannon;
    public float Force;
    public GameObject Target;
    GameObject currentTarget;
    bool isFiring;
    public float RateOfFire;
    public float RateOfFireDefault;
    public float RoF;
    bool FirstAttack;
    public float DamageAmount;
    public int MinionData;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Script cAlled");
        isFiring = false;
        RoF = RateOfFire;
        FirstAttack = true;
        MinionData = 0;
        RateOfFireDefault = RateOfFire;
    }

    // Update is called once per frame
    void Update()
    {
        //Cannon.transform.LookAt(Target.transform);
    }

    void Combat(Collider collider)
    {
        if(Target)
        {
            Cannon.transform.LookAt(Target.transform);
        }


            AttackTimer();
 
        
    }

    void AttackTimer()
    {

        if(FirstAttack)
        {
            Fire();
            FirstAttack = false;
        }
       
        if(RoF<=0)
        {
            RoF = RateOfFire;
            Fire();
        }
        else
        {
            RoF -= Time.deltaTime;
        }
        
    }
    void Fire()
    {
        GameObject CannonBallInstance = Instantiate<GameObject>(CannonBall, Muzzle.transform.position, Muzzle.transform.rotation);
        CannonBallInstance.transform.LookAt(Target.transform);
        CannonBallInstance.GetComponent<Rigidbody>().AddForce(Cannon.transform.forward * Force);   
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == 11)
        {
            MinionData++;
            RateOfFire = RateOfFireDefault * MinionData;
            if (Target == null)
            {
                Debug.Log(collision.name);
                Target = collision.gameObject;
                currentTarget = Target;
                FirstAttack = true;
            }
        }
    }
    private void OnTriggerStay(Collider collisionInfo)
    {
        if(Target != null)
        {
            Combat(collisionInfo);
        }
        else
        {
            UpdateTarget(collisionInfo);
        }
    }

    public  void TakeDamage(float Amount)
    {

        Health -= Amount;

        if (Health <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        Destroy(this.gameObject);
    }

  public void UpdateTarget(Collider collider)
    {
        if(collider.gameObject.layer == 11)
        {
            Target = collider.gameObject;
        }
    }
}
