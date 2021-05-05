using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaiseTheRoofGameController : MonoBehaviour
{
    private AddImageRaiseTheRoof addImageRaiseTheRoof;

    public List<string> Answerstext = new List<string>();
    public List<string> Questionstext = new List<string>();

    public List<Sprite> Answersprite = new List<Sprite>();
    public List<Sprite> Questionsprite = new List<Sprite>();

    public List<Image> Answers = new List<Image>();
    public List<Image> Questions = new List<Image>();

        public List<TextMeshProUGUI> AnswersText = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> QuestionsText = new List<TextMeshProUGUI>();


    public GameObject panel;
    public Animator animator;

    public Transform[] transforms;

    private int reference2;
    private string reference;

    public int number = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        addImageRaiseTheRoof = GetComponent<AddImageRaiseTheRoof>();

        reference2 = PlayerPrefs.GetInt("REFERENCENUMBER");
        reference = PlayerPrefs.GetString("REFERENCE");

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
        Shuffleee();
        Go2();

    }
     
    public void Go2()
    {
        GetButtonsA();
        GetButtonsQ();
    }


    public void Start()
    {
        StartCoroutine(GO());
        transforms = addImageRaiseTheRoof.answer.GetComponentsInChildren<Transform>();
    }
    public void Shuffleee()
    {
        Shuffle(Questionstext, Questionsprite, Answerstext, Answersprite);
    }
    private void Update()
    {
      
    }
    public void GetButtonsQ()
    {
        GameObject[] objectsQ = GameObject.FindGameObjectsWithTag("RaiseTheRoofQ"); 

        for (int i = 0; i < objectsQ.Length; i++)
        {
            QuestionsText.Add(objectsQ[i].GetComponentInChildren<TextMeshProUGUI>());
            Questions.Add(objectsQ[i].GetComponent<Image>());
            objectsQ[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
            Questions[i].sprite = Questionsprite[number];
        }
    }
    public void GetButtonsA()
    {
        GameObject[] objectsA = GameObject.FindGameObjectsWithTag("RaiseTheRoofA");

        for (int i = 0; i < objectsA.Length; i++)
        {
            int number = 0;
            AnswersText.Add(objectsA[i].GetComponentInChildren<TextMeshProUGUI>());
            Answers.Add(objectsA[i].GetComponent<Image>());

            int range = Random.Range(0, 4);


            objectsA[i].GetComponentInChildren<TextMeshProUGUI>().text = Answerstext[number];
            Answers[i].sprite = Answersprite[i];
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

    public void Up()
    {
        panel.transform.position = panel.transform.position + new Vector3(0, panel.transform.localScale.y/2, 0);
        number++;
    }
    public void Down()
    {
        panel.transform.position = panel.transform.position + new Vector3(0,-panel.transform.localScale.y/2, 0);
        number++;
    }
    public void Won()
    {
        animator.Play("Fade-in");
    }
}
