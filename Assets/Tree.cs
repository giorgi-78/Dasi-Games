using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public static float TreeHealth = 40;

    public GameObject Cut1;
    public GameObject Cut2;
    public GameObject Cut3;
    public GameObject Cut4;

    Animator anim;

    public GameObject Spawner1;
    public GameObject Spawner2;

    public GameObject Log;

    public AudioClip WoodHit;
    AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

        TreeHealth = 40;
    }

    // Update is called once per frame
    void Update()
    {

        if (TreeHealth == 30) {
            Cut1.SetActive(false);
        }
        if (TreeHealth == 20)
        {
            Cut2.SetActive(false);
        }
        if (TreeHealth == 10)
        {
            Cut3.SetActive(false);
        }
        if (TreeHealth == 0)
        {
            Cut4.SetActive(false);
        }

        if (TreeHealth <= 0) {
            PlayerMovement.IsBrackingTree = false;
            StartCoroutine("GrowTimer");
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        TreeHealth -= 10f; 
        yield return null;
        //StartCoroutine("Timer");
    }

    IEnumerator GrowTimer()
    {
        yield return new WaitForSeconds(5);
        TreeHealth = 40;
        Cut1.SetActive(true);
        Cut2.SetActive(true);
        Cut3.SetActive(true);
        Cut4.SetActive(true);
        StopCoroutine("GrowTimer");
        //yield return null;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Detector" && TreeHealth >= 10) {
            PlayerMovement.IsBrackingTree = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Detector")
        {
            PlayerMovement.IsBrackingTree = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "NPC_Tools_Axe_004" && PlayerMovement.IsBrackingTree == true)
        {
            anim.Play("TreeGotHit");
            audioSource.PlayOneShot(WoodHit);
            Instantiate(Log, Spawner1.transform.position, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
            Instantiate(Log, Spawner2.transform.position, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
        }
    }
}
