using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoryMatchController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;

    public string[] Q;
    public string[] A;

    public Sprite[] ImageQ;
    public Sprite[] ImageA;

    private bool firstGuess = false, secondGuess = false;
    private int FirstGameIndex, SecondGameIndex;
    private Image firstGuessName, secondGuessName;

    private bool cantouch;

    public List<string> spriteQ = new List<string>();
    public List<Sprite> images = new List<Sprite>();

    public List<Button> btnsQ = new List<Button>(); 

    public Animator animator;
    private Score score;
    private AudioManager audioManager;

    private int reference2;
    private string reference;
   
    public void Start()
    {
        reference = PlayerPrefs.GetString("REFERENCE");
        reference2 = PlayerPrefs.GetInt("REFERENCENUMBER");
        cantouch = false;
        audioManager = FindObjectOfType<Camera>().GetComponent<AudioManager>();
        score = GetComponent<Score>();

        GetButtonsQ();
        AddListners();
        AddgamePuzzle();
        Shuffle(spriteQ, images);

        for (int i = 0; i < reference2*2; i++)
        {
            btnsQ[i].GetComponentInChildren<TextMeshProUGUI>().text = spriteQ[i];
            btnsQ[i].GetComponentInChildren<TextMeshProUGUI>().enabled = true;
            StartCoroutine(BackToNormal());
        }
                    
    }
    IEnumerator BackToNormal()
    {
        yield return new WaitForSeconds(4);
        for (int i = 0; i < reference2*2; i++)
        {
            btnsQ[i].image.sprite = bgImage;
            btnsQ[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            cantouch = true;


        } 
    }    

    // Update is called once per frame
    void GetButtonsQ()
    {
        GameObject[] objectsQ = GameObject.FindGameObjectsWithTag("MemoryMatchQ");

        for (int i = 0; i < reference2*2;i++)
        {
            btnsQ.Add(objectsQ[i].GetComponent<Button>());
            btnsQ[i].image.sprite = bgImage;
        }
    }

    public void AddgamePuzzle ()

    {
        int looper = reference2;
        int index = 0;
        int index2 = 0;
            


        for (int i = 0; i < looper*2;i++)
        {
           if(i <= reference2-1)
            {
                spriteQ.Add(PlayerPrefs.GetString(reference + "Q" + index));
                images.Add(ImageQ[index]);

                index++;
            }
           if(i >= reference2)
           {
                spriteQ.Add(PlayerPrefs.GetString(reference + "A" + index2));
                images.Add(ImageA[index2]);
                index2++;
           }
            

        }
    }

    void AddListners()
    {
        foreach (Button btn in btnsQ)
        {
            btn.onClick.AddListener(() => PickPuzzlesQ());
        }
    }

    private void PickPuzzlesQ()
    {
        if(cantouch == true)
        {
            if (!firstGuess)
            {
                firstGuess = true;
                FirstGameIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
                firstGuessName = btnsQ[FirstGameIndex].GetComponent<Image>();
                btnsQ[FirstGameIndex].GetComponentInChildren<TextMeshProUGUI>().text = spriteQ[FirstGameIndex];
                btnsQ[FirstGameIndex].GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                btnsQ[FirstGameIndex].GetComponent<Image>().sprite = images[FirstGameIndex];
                btnsQ[FirstGameIndex].interactable = false;
                btnsQ[FirstGameIndex].GetComponent<Animator>().Play("QuestionAnim");
            }
            else if (!secondGuess)
            {
                secondGuess = true;
                SecondGameIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
                secondGuessName = btnsQ[SecondGameIndex].GetComponent<Image>();
                btnsQ[SecondGameIndex].GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                btnsQ[SecondGameIndex].GetComponentInChildren<TextMeshProUGUI>().text = spriteQ[SecondGameIndex];
                btnsQ[SecondGameIndex].GetComponent<Image>().sprite = images[SecondGameIndex];
                StartCoroutine(CheckIfTheGameIsFinished());
                btnsQ[SecondGameIndex].GetComponent<Animator>().Play("QuestionAnim");

            }
        }    
        
    }

    IEnumerator CheckIfTheGameIsFinished()
    {
        yield return new WaitForSeconds(0.5f);

        if(firstGuessName.sprite.name == secondGuessName.sprite.name)
        {

            btnsQ[FirstGameIndex].interactable = false;
            btnsQ[SecondGameIndex].interactable = false;
            btnsQ[FirstGameIndex].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            btnsQ[SecondGameIndex].GetComponentInChildren<TextMeshProUGUI>().enabled = false;

            btnsQ[FirstGameIndex].image.color = new Color(0, 0, 0, 0);
            btnsQ[SecondGameIndex].image.color = new Color(0, 0, 0, 0);

            score.correctint++;

            audioManager.Correct();
        }
        else
        {
            btnsQ[FirstGameIndex].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            btnsQ[SecondGameIndex].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            btnsQ[FirstGameIndex].interactable = true;
            score.Cal();
            audioManager.Wrong();
        }
        score.attemps++;
        score.Cal();

        firstGuess = secondGuess = false;
    }

    void Shuffle (List<string> list,List<Sprite> list2)
    {
        for (int i=0; i < reference2*2; i++)
        {
            int randomIndex = Random.Range(i, reference2 * 2);

            string temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;

            Sprite temp2 = list2[i];
            list2[i] = list2[randomIndex];
            list2[randomIndex] = temp2;
        }
    }
   

}
