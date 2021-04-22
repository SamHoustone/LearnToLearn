using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FasterBlasterController : MonoBehaviour
{
    public List<string> Answerstext = new List<string>();
    public List<string> Questionstext = new List<string>();

    public List<TextMeshProUGUI> AnswersText = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> QuestionsText = new List<TextMeshProUGUI>();


    public int number = 0;
    // Start is called before the first frame update
    public List<Sprite> Answersprite = new List<Sprite>();
    public List<Sprite> Questionsprite = new List<Sprite>();

    public List<Image> Answers = new List<Image>();
    public List<Image> Questions = new List<Image>();

    public GameObject customiser;
    public Animator Lost;

    private int reference2;
    private string reference;
    // Start is called before the first frame update
    private void Awake()
    {
        reference2 = PlayerPrefs.GetInt("REFERENCENUMBER");
        reference = PlayerPrefs.GetString("REFERENCE");

        for (int i = 0; i < reference2; i++)
        {
            Questionstext.Add(PlayerPrefs.GetString(reference + "Q" + i));
            Answerstext.Add(PlayerPrefs.GetString(reference + "A" + i));
        }
    }
    public void Start()
    {

        Shuffleee();
        GetButtonsQ();
        GetButtonsA();
    }
    public void Shuffleee()
    {
        Shuffle(Questionstext, Questionsprite, Answerstext, Answersprite);
    }
    private void Update()
    {
    }
    void GetButtonsQ()
    {
        GameObject[] objectsQ = GameObject.FindGameObjectsWithTag("FasterBlasterQ");

        for (int i = 0; i < objectsQ.Length; i++)
        {
            QuestionsText.Add(objectsQ[i].GetComponentInChildren<TextMeshProUGUI>());
            Questions.Add(objectsQ[i].GetComponent<Image>());


            objectsQ[i].GetComponentInChildren<TextMeshProUGUI>().text = Questionstext[i];
            Questions[i].sprite = Questionsprite[i];

        }
    }
    void GetButtonsA()
    {
        GameObject[] objectsA = GameObject.FindGameObjectsWithTag("FasterBlasterA");

        for (int i = 0; i < objectsA.Length; i++)
        {
            AnswersText.Add(objectsA[i].GetComponentInChildren<TextMeshProUGUI>());
            Answers.Add(objectsA[i].GetComponent<Image>());
        }
        GetButtonA2();
    }
    void GetButtonA2()
    {
        GameObject[] objectsA = GameObject.FindGameObjectsWithTag("FasterBlasterA");
        for (int i = 0; i < objectsA.Length; i++)
        {
            int range = Random.Range(0,3);
            objectsA[i].GetComponentInChildren<TextMeshProUGUI>().text = Answerstext[range];
            Answers[i].sprite = Answersprite[range];
        }
    } 
    
    public void Shuffle(List<string> list, List<Sprite> list2, List<string> list3, List<Sprite> list4)
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

            string temp3 = list3[i];
            list3[i] = list3[randomIndex];
            list3[randomIndex] = temp3;

            Sprite temp4 = list4[i];
            list4[i] = list4[randomIndex];
            list4[randomIndex] = temp4;

        }
    }

}
