using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int ScoreMultiplier = 10;
    public Text ScoreText;
    public SnakeHead Player;
    public GameObject SpawnArea;
    public GameObject FoodObject;
    public Canvas GameOverCanvas;
    public Text FinalScoreText;

    internal bool IsGameOver = false;
    internal bool RegularFoodEaten = true;

    private int _score = 0;
    private Food _specialFood;
    private float _initialSnakeTurningRadius;

    void Start()
    {
        GameOverCanvas.gameObject.SetActive(false);
        _initialSnakeTurningRadius = Player.TurningRadius;
        UpdateDisplayScore();
        InvokeRepeating("SpawnSpecialFood", 5, 5);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            ResetGame();
            IsGameOver = false;
        }

        if (!IsGameOver)
        {
            if (RegularFoodEaten)
            {
                SpawnFood();
                RegularFoodEaten = false;
            }
        }
    }

    private void UpdateDisplayScore()
    {
        ScoreText.text = $"Skor: { _score.ToString() }";
    }

    internal void UpdateScore()
    {
        _score = Player.BodySegments.Count;
        UpdateDisplayScore();
    }

    private void ResetScore()
    {
        _score = 0;
        UpdateDisplayScore();
    }

    private GameObject SpawnFood()
    {
        float spawnRadius = 5;
        Vector3 rndPosWithin = new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f), Camera.main.nearClipPlane);
        // rndPosWithin = SpawnArea.transform.TransformPoint(rndPosWithin);
        Vector3 outsideThisPos = Player.transform.position.normalized;
        if (Player.transform.position == Vector3.zero)
        {
            outsideThisPos = Vector3.one;
        }
        Vector3 spawnPosition = rndPosWithin - (outsideThisPos * spawnRadius);
        GameObject newFood = Instantiate(FoodObject, spawnPosition, Quaternion.identity);
        newFood.transform.parent = SpawnArea.transform;
        return newFood;
    }

    public void SpawnSpecialFood()
    {
        if (IsGameOver)
        {
            return;
        }

        if (_score < 5)
        {
            return;
        }

        if (_specialFood != null)
        {
            Destroy(_specialFood.gameObject);
        }

        _specialFood = SpawnFood().GetComponent<Food>();

        int dna = Random.Range(0, 10);

        if (dna <= 5)
        {
            _specialFood.MakeSpecial();
        }
        else if (dna > 5)
        {
            _specialFood.MakeToxic();
        }
    }

    internal void GameOver()
    {
        IsGameOver = true;
        FinalScoreText.text = $"Your Score: {_score.ToString()}";
        GameOverCanvas.gameObject.SetActive(true);
    }

    private void ResetGame()
    {
        ResetScore();
        Player.Size = 1;
        RegularFoodEaten = true;

        GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");

        foreach (var food in foods)
        {
            Destroy(food);
        }

        foreach (var segment in Player.BodySegments)
        {
            Destroy(segment);
        }

        Player.BodySegments.Clear();
        Player.transform.position = Vector3.zero;
        Player.transform.rotation = Quaternion.identity;
        Player.TurningRadius = _initialSnakeTurningRadius;
        GameOverCanvas.gameObject.SetActive(false);
    }
}
