using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonMovement : MonoBehaviour
{
    [SerializeField] bool hitCeiling = false;
    [SerializeField] bool hitGround = false;
    [SerializeField] float width = 0.1f;
    [SerializeField] float height = 0.1f;
    public static float size = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate() {
        if (!hitCeiling && !hitGround) {
            transform.position += transform.up * Time.deltaTime;
            // Only goes up.
        }
        if (hitCeiling && !hitGround) {
            transform.position += -transform.up * Time.deltaTime;
            // Hit Ceiling and didnt hit ground.
        }
        if (hitGround && !hitCeiling) {
            transform.position += transform.up * Time.deltaTime; 
            // Hit Ground and didnt hit ceiling.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            hitGround = true;
            hitCeiling = false;
            if (width < 0.6f) {
                transform.localScale = new Vector3(width, height, 0f);
                width += 0.1f;
                height += 0.1f;
                size = width;
            }
            // When it hits the bottom, it grows. Tracked by width.
            if (width == 0.6f) {
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            // Destroy after four bounces     
        }
        if (collision.gameObject.tag == "Ceiling") {
            hitCeiling = true;
            hitGround = false;
            if (width < 0.6f) {
                transform.localScale = new Vector3(width, height, 0f);
                width += 0.1f;
                height += 0.1f;
                size = width;
            }
            // When it hits the ceiling, it grows. Tracked by width.
            if (width == 0.6f) {
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            // Destroy after four bounces
        }
    }    
}
