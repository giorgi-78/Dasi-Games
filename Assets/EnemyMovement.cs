using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;

    Animator anim;

    bool isMoving = false;
    bool isAttacking = false;

    public static int EnemyHealth = 100;
    public static int EnemyAxeDamage = 10;

    public int Health = EnemyHealth;
    public int AxeDamage = EnemyAxeDamage;

    public Collider col;

    AudioSource audioSource;
    public AudioClip Stab;

    public GameObject player;
    public Collider PlayerAxeCollider;

    public Collider MyAxeCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        EnemyHealth = 100;
        EnemyAxeDamage = 10;

        EnemyHealth = Health;
        EnemyAxeDamage = AxeDamage;   
    }

    void Update()
    {
        enemy.SetDestination(Player.position);

        if (isMoving == true)
        {
            anim.Play("Walk");
        }

        if (isAttacking == true) {
            anim.Play("Attack");
        }

        if (EnemyHealth <= 0) {
            Destroy(gameObject);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            MyAxeCollider.enabled = false;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            MyAxeCollider.enabled = true;
        }


        //თავდასხმის დაწყების და შეწყვეტის მეორე ვარიანტი
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (distance <= 1.3f) {
            isAttacking = true;
            isMoving = false;
            //PlayerMovement.IsBrackingTree = true;
        }
        if (distance > 1.3f) {
            isAttacking = false;
            isMoving = true;
            //PlayerMovement.IsBrackingTree = false;
        }
    }

    private void OnDestroy()
    {
        PlayerMovement.IsBrackingTree = false;
    }

    private IEnumerator Timer()
    {
        anim.SetBool("Attack", true);

        yield return new WaitForSeconds(2);
        yield return null;
        //StartCoroutine("Timer");
    }

    private void OnTriggerEnter(Collider other)
    {
        //თავდასხმის კოდი
        //if (other.gameObject.name == "Player") {
        //    isAttacking = true;
        //    isMoving = false;
        //    PlayerMovement.IsBrackingTree = true;
        //}

        //თუ მოხვდება ცული
        if (other.gameObject.name == "NPC_Tools_Axe_004")
        {
            //audioSource.PlayOneShot(Stab);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //თავდასხმის შეწყვეტის კოდი
        //if (other.gameObject.name == "Player")
        //{
        //    isAttacking = false;
        //    isMoving = true;
        //    PlayerMovement.IsBrackingTree = false;
        //}

        //ცული რომ მოხვდება კოლაიდერს უთიშავს რომ მხოლოდ ერთხელ დაფიქსირდეს შეხება
        if (other.gameObject.name == "NPC_Tools_Axe_004")
        {
            PlayerAxe.hasHit = false;
            PlayerAxeCollider.enabled = true;
        }
    }
}
