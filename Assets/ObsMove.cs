using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsMove : MonoBehaviour
{
    public bool movementEnabled = true;
    public Rigidbody rb;
    public float forwardForce = 2000f;
    void Update()
    {
        if (movementEnabled)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
            if (transform.position.z.CompareTo(50) == 1)
            {
                Destroy(gameObject);
            }

        }
    }
}
