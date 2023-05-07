using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMainGame() {
        SceneManager.LoadScene(1);
    }

    public void InstructionScene() {
        SceneManager.LoadScene(5);
    }

    public void SettingsScreen() {
        SceneManager.LoadScene(6);
    }
}
