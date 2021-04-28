using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FasterBlasterMovement : MonoBehaviour
{
    private bool moveableleft = true;
    private bool moveableright = true;

    private float Right = 0.050f;
    private float Left = -0.050f;

    private Score score;
    public Transform sposition;
    private AudioManager audioManager;

    public LineRenderer lr;

    private FasterBlasterController fasterBlasterController;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<Camera>().GetComponent<AudioManager>();
        fasterBlasterController = FindObjectOfType<Canvas>().GetComponent<FasterBlasterController>();
        score = FindObjectOfType<Canvas>().GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
            StartCoroutine(Shoot());
        }
        if (moveableright == true)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = transform.position + new Vector3(Right, 0, 0);
            }
        }
        if (moveableleft == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = transform.position + new Vector3(Left, 0, 0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TL"))
        {
            moveableleft = false;
        }
        if (collision.CompareTag("TR"))
        {
            moveableright = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TL"))
        {
            moveableleft = true;
        }
        if (collision.CompareTag("TR"))
        {
            moveableright = true;
        }
    }
    IEnumerator Shoot()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up));
        Draw2DRay(transform.position, ray.point);

        void Draw2DRay(Vector2 startpos, Vector2 Endpos)
        {
            lr.SetPosition(0, startpos);
            lr.SetPosition(1, Endpos);
        }
       if(ray)
       {
            if(ray.transform.GetComponent<Image>().sprite.name == transform.GetComponent<Image>().sprite.name)
            {
                ray.transform.GetComponentInParent<FasterBlasterDown>().CorrectOrWrong();
                Debug.Log("Correct");
                score.correctint++;
                audioManager.Correct();
                fasterBlasterController.Go2();
                ray.transform.GetComponent<Animator>().Play("QuestionAnim");
                transform.GetComponent<Animator>().Play("QuestionAnim");

            }
            else
            {
                ray.transform.GetComponentInParent<FasterBlasterDown>().CorrectOrWrong();
                fasterBlasterController.Lost.Play("Fade-in");
                fasterBlasterController.Go2();
                Debug.Log("Wrong");
                score.wrongint++;
                audioManager.Wrong();
                ray.transform.GetComponent<Animator>().Play("QuestionAnim");
                transform.GetComponent<Animator>().Play("QuestionAnim");
            }
            score.attemps++;
            score.Cal();

            lr.enabled = true;

            yield return new WaitForSeconds (0.3f);

            lr.enabled = false;
        }
            
    }    

}
