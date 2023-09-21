using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBuildScript : MonoBehaviour
{

    public GameObject House;
    public GameObject RedHouse;
    public GameObject Price;
    public GameObject WinPanel;

    bool houseBought = false;

    void Start()
    {
        houseBought = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        PlayerMovement.LogCounter -= 300;
        House.SetActive(true);
        Price.SetActive(false);
        WinPanel.SetActive(true);
        houseBought = true;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player") {
            if (PlayerMovement.LogCounter >= 300 && houseBought == false) {
                Destroy(gameObject);
            }
        }
    }
}
