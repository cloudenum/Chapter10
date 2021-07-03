using UnityEngine;

public class Food : MonoBehaviour
{
    public int NutritionValue = 1;
    private SpriteRenderer _sprite;
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    internal void MakeToxic()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.color = Color.red;
        NutritionValue = -1;
    }

    internal void MakeSpecial()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.color = Color.yellow;
        NutritionValue = 2;
    }
}
