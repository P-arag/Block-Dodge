using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float sidewaysForce = 1800f;
    public Spawner spawner;

    void Update()
    {
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
    }

    void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Obstacle"))
        {
            collisionInfo.gameObject.GetComponent<ObsMove>().movementEnabled = false;
            spawner.spawnEnabled = false;
        }
    }
}
