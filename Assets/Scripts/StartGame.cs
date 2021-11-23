using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void run()
    {
        Debug.Log("Game Started");
        SceneManager.LoadScene(1);
    }
}
