using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Functions : MonoBehaviour
{
    public GameObject DeathPanel;
    public GameObject PausePanel;

    void Start()
    {
        DeathPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume() {
        Time.timeScale = 1;
    }

    public void Replay() {
        Time.timeScale = 1;
        DeathPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Application.Quit();
    }
}
