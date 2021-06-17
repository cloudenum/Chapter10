using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject SpawnArea;
    public GameObject ObjectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Camera.main.nearClipPlane);
            rndPosWithin = SpawnArea.transform.TransformPoint(rndPosWithin * .5f);
            Instantiate(ObjectToSpawn, rndPosWithin, transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
