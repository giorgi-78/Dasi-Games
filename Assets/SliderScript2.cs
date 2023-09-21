using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript2 : MonoBehaviour
{

    public Slider slider;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();

        slider.maxValue = EnemyMovement2.EnemyHealth2;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = EnemyMovement2.EnemyHealth2;
    }
}
