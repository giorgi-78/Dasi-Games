using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSliderScript : MonoBehaviour
{

    public Slider slider;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();

        slider.maxValue = PlayerMovement.PlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = PlayerMovement.PlayerHealth;
    }
}
