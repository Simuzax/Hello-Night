using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform target;

    float speed = 2;

    Rigidbody2D rgbd;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        float z = Mathf.Atan2((target.transform.position.y - transform.position.y)
                            , (target.transform.position.x - transform.position.x
                             )) * Mathf.Rad2Deg - 90;

        transform.eulerAngles = new Vector3(0, 0, z);

        if (Vector3.Distance(transform.position, target.position) > 0.5f)
            rgbd.velocity = gameObject.transform.up * speed;
    }
}
