using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asnwer : MonoBehaviour
{
    private FlashDrillController flashDrillController;
    private Score score;
    private AudioManagerFlashDrill audioManager;
    private ScoreCoinAnima scoreCoinAnima;
    public TFGiver tfgiver;
    // Start is called before the first frame update
    void Start()
    {
        tfgiver = FindObjectOfType<TFGiver>();
        scoreCoinAnima = FindObjectOfType<ScoreCoinAnima>();
        audioManager = FindObjectOfType<Camera>().GetComponent<AudioManagerFlashDrill>();
        flashDrillController = FindObjectOfType<Canvas>().GetComponent<FlashDrillController>();
        score = FindObjectOfType<Canvas>().GetComponent<Score>();
    }

    private void Update()
    {
    }

    // Update is called once per frame
    public void CheckIfCorrect()
    {
        if (GetComponent<Image>().sprite.name == flashDrillController.Questions[0].sprite.name)
        {
            score.correctint++;
            score.attemps++;
            StartCoroutine(CorrectWait());
            audioManager.Correct();
            transform.GetComponent<Animator>().Play("QuestionAnim");
            scoreCoinAnima.StartCoinMoveCorrect(transform);
        }
        else
        {
            
            score.wrongint++;
            score.attemps++;
            StartCoroutine(WrongWait());
            audioManager.Wrong();
            transform.GetComponent<Animator>().Play("QuestionAnim");
            scoreCoinAnima.StartCoinMoveWrong(tfgiver.transform);
            if(flashDrillController.Replaying)
            {

            }
            else
            {
                flashDrillController.noofwrongCardGuessed++;
            }

            flashDrillController.wrongAnswers.Add(flashDrillController.Questions[0].sprite);
        }
        
    }

    IEnumerator CorrectWait()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("CORRECT");
        flashDrillController.Text();

    }
    IEnumerator WrongWait()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("WRONG");
        flashDrillController.Text();
    }
}
