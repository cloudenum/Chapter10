using UnityEngine;

public class Box : MonoBehaviour
{
    public GameManager Manager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            Manager.AddScore();
            Invoke("ReActivateBox", 3);
        }
    }

    private void ReActivateBox()
    {
        Vector3 rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Camera.main.nearClipPlane);
        rndPosWithin = Manager.SpawnArea.transform.TransformPoint(rndPosWithin * .5f);
        gameObject.transform.position = rndPosWithin;
        gameObject.SetActive(true);
    }
}
