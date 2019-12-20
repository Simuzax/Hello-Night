using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float walkSpeed = 3;
    float runSpeed = 5;
        
    Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) { movement(); }        
    }

    void movement()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(runSpeed * input * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(walkSpeed * input * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Destroy(gameObject);

            Application.Quit();
        }
    }
}
