using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Enemy1")
        {
            PlayerMovement.IsBrackingTree = true;
        }
        if (other.gameObject.name == "Enemy2")
        {
            PlayerMovement.IsBrackingTree = true;
        }
        if (other.gameObject.name == "Enemy3")
        {
            PlayerMovement.IsBrackingTree = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Enemy1")
        {
            PlayerMovement.IsBrackingTree = false;
        }
        if (other.gameObject.name == "Enemy2")
        {
            PlayerMovement.IsBrackingTree = false;
        }
        if (other.gameObject.name == "Enemy3")
        {
            PlayerMovement.IsBrackingTree = false;
        }
    }
}
