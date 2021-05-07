using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlashDrillController : MonoBehaviour
{
    public List<string> Answerstext = new List<string>();
    public List<string> Questionstext = new List<string>();

    public List<Sprite> Answersprite = new List<Sprite>();
    public List<Sprite> Questionsprite = new List<Sprite>();

    public List<Image> Answers = new List<Image>();
    public List<Image> Questions = new List<Image>();

    public List<TextMeshProUGUI> AnswersText = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> QuestionsText = new List<TextMeshProUGUI>();

    private int cardsLeft;
    public TextMeshProUGUI cardsTLeftText;
    public int noofwrongCardGuessed;

    public List<Sprite> wrongAnswers = new List<Sprite>();
    public List<string> wrongAnswersText = new List<string>();

    public Animator animator;
    private Score score;

    public int number = 0;

    private int reference2;
    private string reference;
    private string one;

    public bool Replaying = false;

    public AudioClip swoosh;
    public AudioSource audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        one = PlayerPrefs.GetString("FD");
        reference2 = PlayerPrefs.GetInt("REFERENCENUMBER");
        reference = PlayerPrefs.GetString("REFERENCE");
        cardsLeft = reference2;

        for (int i = 0; i < reference2; i++)
        {
            Questionstext.Add(PlayerPrefs.GetString(reference + "Q" + i));
            Answerstext.Add(PlayerPrefs.GetString(reference + "A" + i));
        }
    }

    IEnumerator GO()
    {
        //WWW imageQ1 = new WWW(PlayerPrefs.GetString(reference + "QIMAGE1" ));
        //WWW imageQ2 = new WWW(PlayerPrefs.GetString(reference + "QIMAGE1"));
        //WWW imageQ3 = new WWW(PlayerPrefs.GetString(reference + "QIMAGE1"));
        //WWW imageQ4 = new WWW(PlayerPrefs.GetString(reference + "QIMAGE1"));
        //WWW imageQ5 = new WWW(PlayerPrefs.GetString(reference + "QIMAGE1"));
        //WWW imageQ6 = new WWW(PlayerPrefs.GetString(reference + "QIMAGE1"));
        //WWW imageQ7 = new WWW(PlayerPrefs.GetString(reference + "QIMAGE1"));
        //WWW imageQ8 = new WWW(PlayerPrefs.GetString(reference + "QIMAGE1"));

        WWW imageQ1 = new WWW("http://localhost/ll/1.jpeg");
        WWW imageQ2 = new WWW("http://localhost/ll/2.jpeg");
        WWW imageQ3 = new WWW("http://localhost/ll/3.jpeg");
        WWW imageQ4 = new WWW("http://localhost/ll/4.jpeg");
        WWW imageQ5 = new WWW("http://localhost/ll/5.jpeg");
        WWW imageQ6 = new WWW("http://localhost/ll/6.jpeg");
        WWW imageQ7 = new WWW("http://localhost/ll/7.jpeg");
        WWW imageQ8 = new WWW("http://localhost/ll/8.jpeg");

        yield return imageQ1;


        Sprite spriteQ1 = Sprite.Create(imageQ1.texture, new Rect(0, 0, imageQ1.texture.width, imageQ1.texture.height), new Vector2(imageQ1.texture.width / 2, imageQ1.texture.height / 2));
        Sprite spriteQ2 = Sprite.Create(imageQ2.texture, new Rect(0, 0, imageQ2.texture.width, imageQ2.texture.height), new Vector2(imageQ2.texture.width / 2, imageQ2.texture.height / 2));
        Sprite spriteQ3 = Sprite.Create(imageQ3.texture, new Rect(0, 0, imageQ3.texture.width, imageQ3.texture.height), new Vector2(imageQ3.texture.width / 2, imageQ3.texture.height / 2));
        Sprite spriteQ4 = Sprite.Create(imageQ4.texture, new Rect(0, 0, imageQ4.texture.width, imageQ4.texture.height), new Vector2(imageQ4.texture.width / 2, imageQ4.texture.height / 2));
        Sprite spriteQ5 = Sprite.Create(imageQ5.texture, new Rect(0, 0, imageQ5.texture.width, imageQ5.texture.height), new Vector2(imageQ5.texture.width / 2, imageQ5.texture.height / 2));
        Sprite spriteQ6 = Sprite.Create(imageQ6.texture, new Rect(0, 0, imageQ6.texture.width, imageQ6.texture.height), new Vector2(imageQ6.texture.width / 2, imageQ6.texture.height / 2));
        Sprite spriteQ7 = Sprite.Create(imageQ7.texture, new Rect(0, 0, imageQ7.texture.width, imageQ7.texture.height), new Vector2(imageQ7.texture.width / 2, imageQ7.texture.height / 2));
        Sprite spriteQ8 = Sprite.Create(imageQ8.texture, new Rect(0, 0, imageQ8.texture.width, imageQ8.texture.height), new Vector2(imageQ8.texture.width / 2, imageQ8.texture.height / 2));


        Questionsprite[0] = spriteQ1;
        Questionsprite[1] = spriteQ2;
        Questionsprite[2] = spriteQ3;
        Questionsprite[3] = spriteQ4;
        Questionsprite[4] = spriteQ5;
        Questionsprite[5] = spriteQ6;
        Questionsprite[6] = spriteQ7;
        Questionsprite[7] = spriteQ8;

        for (int i = 0; i < reference2; i++)
        {
            Questionsprite[i].name = i.ToString();
        }
        Go2();
    }
   public void Go2 ()
    {
        Shuffle(Questionstext, Questionsprite);
        Shuffle2(Answerstext, Answersprite);
        Text();
    }
    public void Text()
    {
        GetButtonsA();
        GetButtonsQ();
    }
    public void Start()
    {
        score = FindObjectOfType<Canvas>().GetComponent<Score>();
        StartCoroutine(GO());
    }
    public void Shuffleee()
    {
        Shuffle(Questionstext, Questionsprite);
    }
    public void shufleee2()
    {
        Shuffle2(Answerstext, Answersprite);
    }
    private void Update()
    {
        if(cardsLeft == 0)
        {
            Replaying = true;
        }
        if(Replaying == true)
        {
            cardsTLeftText.text = "Replaying : " + noofwrongCardGuessed.ToString();
        }
        else
        {
            cardsTLeftText.text = "Cards Remaining : " + cardsLeft.ToString();
        }

        if(number == 8)
        {
            number = 0;
        }
    }
   public void GetButtonsQ()
    {      
        if (one == "false")
        {
            GameObject[] objectsQ = GameObject.FindGameObjectsWithTag("FlashDrillQ");
            if (Replaying == false)
            {
                for (int i = 0; i < objectsQ.Length; i++)
                {
                    QuestionsText.Add(objectsQ[i].GetComponentInChildren<TextMeshProUGUI>());
                    Questions.Add(objectsQ[i].GetComponent<Image>());

                    objectsQ[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
                    objectsQ[i].GetComponent<Image>().sprite = Questionsprite[number];
                    number++;
                }
            }
            else
            {
                for (int i = 0; i < objectsQ.Length; i++)
                {
                    QuestionsText.Add(objectsQ[i].GetComponentInChildren<TextMeshProUGUI>());
                    Questions.Add(objectsQ[i].GetComponent<Image>());

                    objectsQ[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
                    objectsQ[i].GetComponent<Image>().sprite = wrongAnswers[number];
                    number++;
                }
            }
        }
        else
        {
            GameObject[] objectsQ = GameObject.FindGameObjectsWithTag("FlashDrillQ");
            if (Replaying == false)
            {
                for (int i = 0; i < objectsQ.Length; i++)
                {
                    Debug.Log("Q");

                    QuestionsText.Add(objectsQ[i].GetComponentInChildren<TextMeshProUGUI>());
                    Questions.Add(objectsQ[i].GetComponent<Image>());

                    objectsQ[i].GetComponentInChildren<TextMeshProUGUI>().text = Answerstext[number];
                    objectsQ[i].GetComponent<Image>().sprite = Answersprite[number];
                    number++;
                }
            }
            else
            {
                for (int i = 0; i < objectsQ.Length; i++)
                {
                    Debug.Log("Q");

                    QuestionsText.Add(objectsQ[i].GetComponentInChildren<TextMeshProUGUI>());
                    Questions.Add(objectsQ[i].GetComponent<Image>());

                    objectsQ[i].GetComponentInChildren<TextMeshProUGUI>().text = Answerstext[number];
                    objectsQ[i].GetComponent<Image>().sprite = Answersprite[number];
                    number++;
                }
            }
        }
        
        
    }
    public void GetButtonsA()
    {
        Debug.Log("A");
        
            GameObject[] objectsA = GameObject.FindGameObjectsWithTag("FlashDrillA");
        if(one == "false")
        {
            for (int i = 0; i < objectsA.Length; i++)
            {
                AnswersText.Add(objectsA[i].GetComponentInChildren<TextMeshProUGUI>());
                Answers.Add(objectsA[i].GetComponent<Image>());

                objectsA[i].GetComponentInChildren<TextMeshProUGUI>().text = Answerstext[i];
                objectsA[i].GetComponent<Image>().sprite = Answersprite[i];
            }
        }
        else
        {
            for (int i = 0; i < objectsA.Length; i++)
            {
                AnswersText.Add(objectsA[i].GetComponentInChildren<TextMeshProUGUI>());
                Answers.Add(objectsA[i].GetComponent<Image>());

                objectsA[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
                objectsA[i].GetComponent<Image>().sprite = Questionsprite[i];

            }
        }
          
    }
    public void Shuffle(List<string> list, List<Sprite> list2)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);

            string temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;

            Sprite temp2 = list2[i];
            list2[i] = list2[randomIndex];
            list2[randomIndex] = temp2;

        }
    }
    public void Shuffle2(List<string> list, List<Sprite> list2)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);

            string temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;

            Sprite temp2 = list2[i];
            list2[i] = list2[randomIndex];
            list2[randomIndex] = temp2;

        }
    }
    public void Correct()
    {
        audioSource.clip = swoosh;
        audioSource.Play();
        animator.Play("right");
        score.Cal();

        if(Replaying == true)
        {
            noofwrongCardGuessed--;
        }
        else
        {
            cardsLeft--;
        }
    }
    public void Wrong()
    {
        audioSource.clip = swoosh;
        audioSource.Play();
        animator.Play("left");
        score.Cal();
        cardsLeft--;
    }
}
