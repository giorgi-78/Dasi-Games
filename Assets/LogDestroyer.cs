using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogDestroyer : MonoBehaviour
{

    public GameObject LogSpawner;
    public GameObject bag;

    void Start()
    {
        LogSpawner = GameObject.FindWithTag("LogSpawner");
        bag = GameObject.FindWithTag("Bag");

        transform.parent = LogSpawner.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, bag.transform.position);

        //if (distance <= 2)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnDestroy()
    {
        PlayerMovement.LogCounter += 1;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bag")
        {
            Destroy(gameObject);
        }
    }
}
