using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealthBar : MonoBehaviour
{
    TowerController EnemyTower;
    Vector3 HealthBarPosition;
    GameObject Slider;
    Slider healthbar;
    // Start is called before the first frame update
    void Start()
    {
        EnemyTower = this.GetComponent<TowerController>();
        HealthBarPosition = this.transform.position;
        Slider = GameObject.Find("EnemyTower/Canvas/Slider");
        healthbar = Slider.GetComponent<Slider>();
        if(healthbar == null)
        {
            Debug.Log("Fail");
        }
        ShowHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    void ShowHealthBar()
    {
        if(EnemyTower)
        {
            Vector3 Offset = new Vector3(0, 65, 0);
            Slider.SetActive(true);
            Slider.transform.position = Camera.main.WorldToScreenPoint(HealthBarPosition) + Offset ;
        }
    }

    void UpdateHealthBar()
    {
        healthbar.value = EnemyTower.Health / EnemyTower.MaxHealth;
        HealthBarPosition = this.transform.position;
        ShowHealthBar();
    }
}
