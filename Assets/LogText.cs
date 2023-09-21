using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogText : MonoBehaviour
{
    public Text logText;

    void Start()
    {
        logText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        logText.text = "Logs: " + PlayerMovement.LogCounter;
    }
}
