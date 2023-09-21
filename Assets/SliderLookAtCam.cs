using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderLookAtCam : MonoBehaviour
{

    public Transform Cam;

    void Start()
    {
        
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + Cam.forward);
    }
}
