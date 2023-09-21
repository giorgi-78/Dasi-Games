using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAxe3 : MonoBehaviour
{

    public AudioClip Stab;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            audioSource.PlayOneShot(Stab);
            PlayerMovement.PlayerHealth -= EnemyMovement3.EnemyAxeDamage3;
        }
    }
}
