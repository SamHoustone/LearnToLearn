using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCoinAnima : MonoBehaviour
{
    public float speed;

    public Transform target;
    public GameObject coinPrefab;
    public Camera camera;



    // Start is called before the first frame update
    void Start()
    {
        if(camera == null)
        {
            camera = Camera.main;
        }    
    }

    // Update is called once per frame
    public void StartCoinMove(Vector3 _initial)
    {
        Vector2 targetPos = camera.ScreenToWorldPoint(new Vector3(target.position.x,target.position.x,camera.transform.position.z * -1));
        GameObject _coin = Instantiate(coinPrefab, transform);

        StartCoroutine(MoveCoin(_coin.transform, _initial, targetPos));
    }

    IEnumerator MoveCoin(Transform obj, Vector3 Startpos, Vector3 EndPos)
    {
        float time = 0;

        while (time < 1)
        {
            time += speed * Time.deltaTime;
            obj.position = Vector3.Lerp(Startpos, EndPos, time);
        }

        yield return null;
    }
}
