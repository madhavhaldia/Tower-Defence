using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTakeDamage : MonoBehaviour
{

    TowerController towerController;
    public CannonController cannonController;
    // Start is called before the first frame update
    void Start()
    {
        towerController = GameObject.Find("EnemyTower").GetComponent<TowerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == 12)
        {

            towerController.TakeDamage(cannonController.DamageAmount);
            Destroy(collider.gameObject);
            
        }
    }
}
