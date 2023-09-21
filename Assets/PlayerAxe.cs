using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxe : MonoBehaviour
{
    public Collider axeCollider;

    public static bool hasHit;

    public GameObject player;

    AudioSource audioSource;
    public AudioClip Stab;

    void Start()
    {
        axeCollider = GetComponent<BoxCollider>();

        audioSource = GetComponent<AudioSource>();

        hasHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (AnimController.AttackAnimPlaying == true) {
            axeCollider.enabled = true;
        }
        if (AnimController.AttackAnimPlaying == false)
        {
            axeCollider.enabled = false;
        }

        //if (hasHit == true)
        //{
        //    axeCollider.enabled = false;
        //}
        //else {
        //    axeCollider.enabled = true;
        //}
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        axeCollider.enabled = true;
        yield return null;
        //StartCoroutine("Timer");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tree" && PlayerMovement.IsBrackingTree == true) {
            if (Tree.TreeHealth >= 10) { 
                Tree.TreeHealth -= 10;
            }
        }
        if (other.gameObject.name == "Tree2" && PlayerMovement.IsBrackingTree == true)
        {
            if (Tree2.TreeHealth >= 10)
            {
                Tree2.TreeHealth -= 10;
            }
        }
        if (other.gameObject.name == "Tree3" && PlayerMovement.IsBrackingTree == true)
        {
            if (Tree3.TreeHealth >= 10)
            {
                Tree3.TreeHealth -= 10;
            }
        }

        //თუ მოხვდება ენემის
        if (other.gameObject.name == "Enemy1" && hasHit == false) {
            EnemyMovement.EnemyHealth -= PlayerMovement.PlayerAxeDamage;
            audioSource.PlayOneShot(Stab);
            hasHit = true;
            axeCollider.enabled = false;
        }

        if (other.gameObject.name == "Enemy2" && hasHit == false)
        {
            EnemyMovement2.EnemyHealth2 -= PlayerMovement.PlayerAxeDamage;
            audioSource.PlayOneShot(Stab);
            hasHit = true;
            axeCollider.enabled = false;
        }

        if (other.gameObject.name == "Enemy3" && hasHit == false)
        {
            EnemyMovement3.EnemyHealth3 -= PlayerMovement.PlayerAxeDamage;
            audioSource.PlayOneShot(Stab);
            hasHit = true;
            axeCollider.enabled = false;
        }
    }
}
