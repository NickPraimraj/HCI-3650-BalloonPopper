using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMovement : MonoBehaviour
{
    public float projectileSpeed = 10; 
    // ^^^ Needs to be changed in unity due to it not using a [serializeField]
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * projectileSpeed;
        // Added in a rigid2dBody for my pin
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Balloon") {
            if (BalloonMovement.size == 0.1f) {
                ScoreSystem.scoreValue += 1;
            }
            if (BalloonMovement.size == 0.2f) {
                ScoreSystem.scoreValue += 2;
            }
            if (BalloonMovement.size == 0.3f) {
                ScoreSystem.scoreValue += 3;
            }
            if (BalloonMovement.size == 0.4f) {
                ScoreSystem.scoreValue += 4;
            }
            if (BalloonMovement.size == 0.5f) {
                ScoreSystem.scoreValue += 5;
            }
            if (BalloonMovement.size == 0.6f) {
                ScoreSystem.scoreValue += 6;
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        } 
        else {
            Destroy(gameObject); // Destroys the pin on any collision
        }
    }
}
