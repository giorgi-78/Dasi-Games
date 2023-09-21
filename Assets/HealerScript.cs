using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerScript : MonoBehaviour
{

    int MaxHealth = PlayerMovement.PlayerHealth;

    void Start()
    {
        MaxHealth = PlayerMovement.PlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && PlayerMovement.PlayerHealth <= MaxHealth) {
            PlayerMovement.PlayerHealth++;
        }
    }
}
