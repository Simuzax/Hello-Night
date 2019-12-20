using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 5;

    Vector2 direction = new Vector2(1, 0);

    float timerSelfDestruct = 0;
    float timerSelfDestruct_Max = 5;

    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        timerSelfDestruct = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (Time.time >= timerSelfDestruct + timerSelfDestruct_Max)
        {
            Destroy(gameObject);

            timerSelfDestruct = Time.time;
        }        
    }

    private void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Destroy(collision.gameObject);

            scoreManager.score++;

            Destroy(gameObject);            
        }
    }
}
