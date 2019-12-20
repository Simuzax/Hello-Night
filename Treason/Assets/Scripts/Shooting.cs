using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootAt();
        }
    }

    void shootAt()
    {
        Vector2 instantiatePosition = new Vector2(transform.position.x + 1, transform.position.y);

        GameObject b = Instantiate(bullet, instantiatePosition, Quaternion.identity);
    }
}
