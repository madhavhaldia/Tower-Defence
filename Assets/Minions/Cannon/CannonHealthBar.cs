using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonHealthBar : MonoBehaviour
{
    CannonController ThisObject;
    Vector3 HealthBarPosition;
    GameObject Slider;
    Slider healthbar;
    // Start is called before the first frame update
    void Start()
    {
        ThisObject = this.GetComponent<CannonController>();
        HealthBarPosition = this.transform.position;
        Slider = this.transform.Find("Canvas/Slider").gameObject;
        healthbar = Slider.GetComponent<Slider>();
        if (healthbar == null)
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
        if (ThisObject)
        {
            Vector3 Offset = new Vector3(0, 25, 0);
            Slider.SetActive(true);
            Slider.transform.position = Camera.main.WorldToScreenPoint(HealthBarPosition) + Offset;
        }
    }

    void UpdateHealthBar()
    {
        healthbar.value = ThisObject.Health / ThisObject.MaxHealth;
        HealthBarPosition = this.transform.position;
        ShowHealthBar();
    }
}
