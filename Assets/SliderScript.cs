using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    public Slider slider;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();

        slider.maxValue = EnemyMovement.EnemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = EnemyMovement.EnemyHealth;
    }
}
