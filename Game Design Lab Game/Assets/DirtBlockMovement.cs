using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBlockMovement : MonoBehaviour
{
    [SerializeField] bool contactCeiling = false;
    [SerializeField] bool contactGround = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Moves it.
    void FixedUpdate() {
        if (!contactCeiling && !contactGround) {
            transform.position += transform.up * Time.deltaTime * 3;
            // Only goes up.
        }
        if (contactCeiling && !contactGround) {
            transform.position += -transform.up * Time.deltaTime * 3;
            // Hit Ceiling and didnt hit ground.
        }
        if (contactGround && !contactCeiling) {
            transform.position += transform.up * Time.deltaTime * 3; 
            // Hit Ground and didnt hit ceiling.
        }
    }

    // Bounces it then moves it.
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            contactGround = true;
            contactCeiling = false;    
        }
        if (collision.gameObject.tag == "Ceiling") {
            contactCeiling = true;
            contactGround = false;
        }
    } 
}
