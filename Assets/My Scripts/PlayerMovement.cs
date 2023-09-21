using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;

    [SerializeField] private AnimController _animatorController;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;

    private Vector3 _moveVector;

    public static bool IsBrackingTree = false;

    public GameObject Walk;

    public GameObject Log;
    public GameObject LogSpawner;

    public static int LogCounter = 0;

    public static int PlayerHealth = 100;
    public int Health = 100;

    public GameObject DeathPanel;

    public static int PlayerAxeDamage = 25;
    public int AxeDamage = 25;

    private void Awake()
    {
        //PlayerHealth = 100;
        Time.timeScale = 1;

        _rigidbody = GetComponent<Rigidbody>();

        PlayerHealth = Health;
        PlayerAxeDamage = AxeDamage;
        Health = 100;
        AxeDamage = 25;
        IsBrackingTree = false;
        LogCounter = 0;
    }

    void Update()
    {
        Move();

        if (PlayerHealth <= 0) {
            DeathPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * _moveSpeed * Time.deltaTime;
        _moveVector.z = _joystick.Vertical * _moveSpeed * Time.deltaTime;

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _rotateSpeed * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(direction);

                _animatorController.PlayRun();
                Walk.SetActive(true);
        }

            else if (_joystick.Horizontal == 0 && _joystick.Vertical == 0 && IsBrackingTree == false)
            {
                _animatorController.PlayIdle();
                Walk.SetActive(false);
                Walk.SetActive(false);
            } 
        
            else if (_joystick.Horizontal == 0 && _joystick.Vertical == 0 && IsBrackingTree == true)
            {
                _animatorController.PlayAttack();

                Walk.SetActive(false);
            }

        _rigidbody.MovePosition(_rigidbody.position + _moveVector);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Log") {
            Instantiate(Log, LogSpawner.transform.position, LogSpawner.transform.rotation);
            Destroy(collision.gameObject);
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.name == "Enemy1")
    //    {
    //        IsBrackingTree = true;
    //    }
    //    if (other.gameObject.name == "Enemy2")
    //    {
    //        IsBrackingTree = true;
    //    }
    //    if (other.gameObject.name == "Enemy3")
    //    {
    //        IsBrackingTree = true;
    //    }
    //}


    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.name == "Enemy1")
    //    {
    //        IsBrackingTree = false;
    //    }
    //    if (other.gameObject.name == "Enemy2")
    //    {
    //        IsBrackingTree = false;
    //    }
    //    if (other.gameObject.name == "Enemy3")
    //    {
    //        IsBrackingTree = false;
    //    }
    //}
}