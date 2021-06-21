using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int _score = 0;

    public Text ScoreText;
    public CircleController player;
    public GameObject SpawnArea;
    public GameObject ObjectToSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void UpdateDisplayScore()
    {
        ScoreText.text = $"Skor: { _score.ToString() }";
    }

    internal void AddScore()
    {
        _score++;
        UpdateDisplayScore();
    }
}
