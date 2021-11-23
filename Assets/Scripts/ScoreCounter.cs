using UnityEngine.UI;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public Text score;
    public Spawner spawner;
    // Update is called once per frame
    void Update()
    {
        score.text = spawner.waveCount.ToString();
    }
}
