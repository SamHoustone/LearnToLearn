using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCoinAnima : MonoBehaviour
{
    public float speed;

    public Transform target;
    public GameObject coinPrefab;
    public Camera camera;
    public GameObject[] gos;

    private int ScorePoints;
    public TextMeshProUGUI ShazakPointsText;

    // Start is called before the first frame update
    void Start()
    {
        if(camera == null)
        {
            camera = Camera.main;
        }    
    }

    private void Update()
    {
        ShazakPointsText.text = ScorePoints.ToString();
    }

    // Update is called once per frame
    public void StartCoinMoveCorrect(Transform _initial)
    {
        Transform targetPos = target;
        for(int i = 0; i < 20; i++)
        {
            GameObject _coin = Instantiate(coinPrefab, _initial);
            _coin.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.RandomRange(-8, 8), Random.RandomRange(-8, 8), Random.RandomRange(-8, 8)), ForceMode2D.Impulse);
        }
        ScorePoints = ScorePoints + 20;
    }
    public void StartCoinMoveWrong(Transform _initial)
    {
        Vector2 targetPos = target.position;
        for (int i = 0; i < 10; i++)
        {
            GameObject _coin = Instantiate(coinPrefab, _initial);
            _coin.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.RandomRange(-8, 8), Random.RandomRange(-8, 8), Random.RandomRange(-8, 8)), ForceMode2D.Impulse);
        }
        ScorePoints = ScorePoints - 10;
    }

    IEnumerator MoveCoin(Transform obj, Vector3 Startpos, Transform EndPos)
    {
        float time = 0;

        while (time < 1)
        {
            time += speed * Time.deltaTime;
            obj.position = Startpos;

            yield return new WaitForSeconds(5);

            Destroy(obj.GetComponent<Rigidbody2D>());
            obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            obj.position = Vector3.Lerp(Startpos, EndPos.position, time);

            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }
}
