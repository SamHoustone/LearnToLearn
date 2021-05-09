using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Asnwer : MonoBehaviour
{
    private FlashDrillController flashDrillController;
    private Score score;
    private AudioManagerFlashDrill audioManager;
    private ScoreCoinAnima scoreCoinAnima;
    public TFGiver tfgiver;
    private string one; 

    private bool canInteract = true;
    // Start is called before the first frame update
    void Start()
    {
        one = PlayerPrefs.GetString("FD");
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
    {         if (canInteract == true)
          {
                if (GetComponent<Image>().sprite.name == flashDrillController.Questions[0].sprite.name)
                {
                audioManager.Tap();
                    Debug.Log("CK");
                    score.correctint++;
                    score.attemps++;
                    StartCoroutine(CorrectWait());
                    audioManager.Correct();
                    transform.GetComponent<Animator>().Play("QuestionAnim");
                    scoreCoinAnima.StartCoinMoveCorrect(transform);
                }
                else
             {
                audioManager.Tap();
                Debug.Log("FU");
                    score.wrongint++;
                    score.attemps++;
                    StartCoroutine(WrongWait());
                    audioManager.Wrong();
                    transform.GetComponent<Animator>().Play("QuestionAnim");
                    scoreCoinAnima.StartCoinMoveWrong(tfgiver.transform);
                    if (flashDrillController.Replaying)
                    {

                    }
                    else
                    {
                        flashDrillController.noofwrongCardGuessed++;
                    }
                if (one == "false" && flashDrillController.Replaying == false)
                {

                    flashDrillController.wrongAnswers.Add(flashDrillController.Questions[0].sprite);
                }
                if(one == "true" && flashDrillController.Replaying == false)
                {
                    flashDrillController.wrongAnswersText.Add(flashDrillController.Questions[0].GetComponentInChildren<TextMeshProUGUI>().text);
                }
                   
            }
          }
            canInteract = false;

    }

    IEnumerator CorrectWait()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("CORRECT");
        flashDrillController.Text();

        yield return new WaitForSeconds(0.6f);

        canInteract = true;

    }
    IEnumerator WrongWait()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("WRONG");
        flashDrillController.Text();
        yield return new WaitForSeconds(0.6f);

        canInteract = true;

    }
}
