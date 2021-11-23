using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float sidewaysForce = 1800f;
    public Spawner spawner;
    public GameObject gameOverUI;
    private bool movementEnabled = true;

    void Update()
    {
        if (movementEnabled)
        {
            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            else if (Input.GetKey("d") || Input.GetKey("right"))
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (transform.position.y.CompareTo(0) == -1)
            {
                StopEverything();
                gameOverUI.SetActive(true);
                Debug.Log("Game Over1");
                StartCoroutine(reloadAfterSeconds(4));
            }
        }
    }

    void StopEverything()
    {
        spawner.spawnEnabled = false;
        movementEnabled = false;
    }

    IEnumerator reloadAfterSeconds(int secs)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene(0);
    }

    void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Obstacle"))
        {
            collisionInfo.gameObject.GetComponent<ObsMove>().movementEnabled = false;
            StopEverything();
            Debug.Log("Game Over");
        }
    }
}
