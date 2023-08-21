using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int healthPoints = 30;
    public int healthPointsMax = 30;
    [SerializeField] Slider sliderHealth;
    // Start is called before the first frame update
    void Start()
    {
        sliderHealth.maxValue = healthPointsMax;
        sliderHealth.value = healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increase(int health)
    {
        if (healthPoints + health >= healthPointsMax) return;
        healthPoints += health;
        sliderHealth.value = healthPoints;
    }

    public void decrease(int health)
    {
        if (healthPoints - health <= 0)
        {
            healthPoints = 0;
        }
        else
        {
            healthPoints -= health;
        }
        sliderHealth.value = healthPoints;
        if (healthPoints <= 0) {
            death();
        }
    }

    void death()
    {
        Destroy(this.gameObject);
    }
}
