using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform projectileStart;
    public GameObject pin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        if (!PauseMenuScript.isPaused) {
            if (Input.GetMouseButtonDown(0)) {
            Instantiate(pin, projectileStart.position, projectileStart.rotation);
            }
        }
    }
}
