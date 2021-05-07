using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaiseTheRoofMovement : MonoBehaviour
{
    private bool moveableleft = true;
    private bool moveableright = true;

    private float Right = 12;
    private float Left = -12;
    private float Down = -0.01f;

    private Score score;

    public int median;
    public int median2;

    private Vector3 one;
    private Vector3 two;
    private Vector3 three;

    public Vector3 startpos;
    private RaiseTheRoofGameController canvas;
    private AudioManager audioManager;

    private ScoreCoinAnima scoreCoinAnima;
    private TFGiver tfgiver;

    public RaiseTheRoofGameController raiseTheRoofGameController;
    // Start is called before the first frame update
    void Start()
    {
        tfgiver = FindObjectOfType<TFGiver>();
        scoreCoinAnima = FindObjectOfType<ScoreCoinAnima>();
        audioManager = FindObjectOfType<Camera>().GetComponent<AudioManager>();
        score = FindObjectOfType<Canvas>().GetComponent<Score>();
        startpos = transform.position;
        raiseTheRoofGameController = FindObjectOfType<Canvas>().GetComponent<RaiseTheRoofGameController>();
        transform.position = startpos;
    }

    // Update is called once per frame
    void Update()
    {

        if (moveableright == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(median2 == 0)
                {
                    median2 = 1;
                    transform.position = new Vector3(raiseTheRoofGameController.transforms[6].transform.position.x, transform.position.y, transform.position.z);
                }
                if(median2 == -1)
                {
                    median2 = 0;
                    transform.position = new Vector3(raiseTheRoofGameController.transforms[4].transform.position.x, transform.position.y,transform.position.z);
                }
            }
        }
        if (moveableleft == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                if (median2 == 0)
                {
                    median2 = -1;
                    transform.position = new Vector3(raiseTheRoofGameController.transforms[2].transform.position.x, transform.position.y,transform.position.z);
                }
                if(median2 == 1)
                {
                    median2 = 0;
                    transform.position = new Vector3(raiseTheRoofGameController.transforms[4].transform.position.x, transform.position.y, transform.position.z);
                }
            }
        }
          if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + new Vector3(0, Down* -0.0005f, 0);
        }
          else
        {
            transform.position = transform.position + new Vector3(0, -0.01f, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("TL"))
        {
            moveableleft = false;
           
        }
        if (collision.CompareTag("TR"))
        {
            moveableright = false;
        }
        if(collision.CompareTag("RaiseTheRoofA"))
        {
            if (collision.GetComponent<Image>().sprite.name == GetComponent<Image>().sprite.name)
            {
                                raiseTheRoofGameController.Up();
                raiseTheRoofGameController.Go2();
                Debug.Log("Correct");
                score.correctint++;
                transform.position = startpos;
                audioManager.Correct();
                collision.GetComponent<Animator>().Play("QuestionAnim");
                median2 = 0;
                median++;


                scoreCoinAnima.StartCoinMoveCorrect(collision.transform);
            }
            else
            {
                raiseTheRoofGameController.Go2();
                Debug.Log("Wrong");
                transform.position = startpos;
                audioManager.Wrong();
                collision.GetComponent<Animator>().Play("QuestionAnim");
                score.wrongint++;
                median2 = 0;
                if (median > 0)
                {
                    median--;
                    raiseTheRoofGameController.Down();
                }
                else
                {
                    raiseTheRoofGameController.number++;
                }
                scoreCoinAnima.StartCoinMoveWrong(tfgiver.transform);


            }
            if(median == 12)
            {
                raiseTheRoofGameController.Won();
            }
            score.attemps++;
            score.Cal();
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
}
