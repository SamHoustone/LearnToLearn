using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DragMatchController : MonoBehaviour
{

    public List<string> Answerstext = new List<string>();
    public List<string> Questionstext = new List<string>();

    public List<Transform> PlaceHolders = new List<Transform>();
    public List<Sprite> Answersprite = new List<Sprite>();
    public List<Sprite> Questionsprite = new List<Sprite>();

    public List<string> URLSQ = new List<string>();
    public List<string> URLSA = new List<string>();

    private List<Image> Answers = new List<Image>();
    private List<Image> Questions = new List<Image>();

    private List<TextMeshProUGUI> AnswersText = new List<TextMeshProUGUI>();
    private List<TextMeshProUGUI> QuestionsText = new List<TextMeshProUGUI>();

    public GameObject coustomiser;
    private string one;

    private int reference2;
    private string reference;
    private Sprite spriteQ7;

    public float size;
    private AddImageDrag addImageDrag;

    // Start is called before the first frame update
    [System.Obsolete]
    private void Awake()
    {
        addImageDrag = FindObjectOfType<AddImageDrag>();
        for (int i = 0; i < reference2; i++)
        {

        }

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

        for(int i = 0; i < reference2;i++)
        {
            Questionsprite[i].name = i.ToString();
        }


        Shuffle(Questionstext, Questionsprite);
        Shuffle2(Answerstext, Answersprite);
        GetButtonsQ();
        GetButtonsA();


    }    
    void Start()
    {
        one = PlayerPrefs.GetString("DM");
        StartCoroutine(GO());
        Update();
    }

    private void Update() 
    {
      PlaceHolders[0].transform.position = addImageDrag.Qpics[0].transform.position;
      PlaceHolders[1].transform.position = addImageDrag.Qpics[1].transform.position;
      PlaceHolders[2].transform.position = addImageDrag.Qpics[2].transform.position;
      PlaceHolders[3].transform.position = addImageDrag.Qpics[3].transform.position;
      PlaceHolders[4].transform.position = addImageDrag.Qpics[4].transform.position;
      PlaceHolders[5].transform.position = addImageDrag.Qpics[5].transform.position;
      PlaceHolders[6].transform.position = addImageDrag.Qpics[6].transform.position;
      PlaceHolders[7].transform.position = addImageDrag.Qpics[7].transform.position;

      PlaceHolders[0].GetComponent<RawImage>().color = addImageDrag.Qpics[0].GetComponent<Image>().color;
       PlaceHolders[1].GetComponent<RawImage>().color = addImageDrag.Qpics[1].GetComponent<Image>().color;
        PlaceHolders[2].GetComponent<RawImage>().color = addImageDrag.Qpics[2].GetComponent<Image>().color;
         PlaceHolders[3].GetComponent<RawImage>().color = addImageDrag.Qpics[3].GetComponent<Image>().color;
          PlaceHolders[4].GetComponent<RawImage>().color = addImageDrag.Qpics[4].GetComponent<Image>().color;
           PlaceHolders[5].GetComponent<RawImage>().color = addImageDrag.Qpics[5].GetComponent<Image>().color;
            PlaceHolders[6].GetComponent<RawImage>().color = addImageDrag.Qpics[6].GetComponent<Image>().color;
             PlaceHolders[7].GetComponent<RawImage>().color = addImageDrag.Qpics[7].GetComponent<Image>().color;
    }

    void GetButtonsQ()
    {
        GameObject[] objectsQ = GameObject.FindGameObjectsWithTag("DragMatchA");

        if (one == "true")
        {
            for (int i = 0; i < objectsQ.Length; i++)
            {
                Questions.Add(objectsQ[i].GetComponent<Image>());
                QuestionsText.Add(objectsQ[i].GetComponentInChildren<TextMeshProUGUI>());

                objectsQ[i].GetComponent<Image>().sprite = Answersprite[i];
                objectsQ[i].GetComponentInChildren<TextMeshProUGUI>().text = Answerstext[i];
                objectsQ[i].GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Questionsprite[i].rect.width,Questionsprite[i].rect.height)/size;
            }
        }
        else
        {
            for (int i = 0; i < objectsQ.Length; i++)
            {
                Questions.Add(objectsQ[i].GetComponent<Image>());
                QuestionsText.Add(objectsQ[i].GetComponentInChildren<TextMeshProUGUI>());

                objectsQ[i].GetComponent<Image>().sprite = Answersprite[i];
                objectsQ[i].GetComponentInChildren<TextMeshProUGUI>().text = Answerstext[i];
                objectsQ[i].GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Questionsprite[i].rect.width,Questionsprite[i].rect.height)/size;
            }
        }

    }
    void GetButtonsA()
    {
        GameObject[] objectsA = GameObject.FindGameObjectsWithTag("DragMatchQ");

        if(one == "true")
        {
            for (int i = 0; i < objectsA.Length; i++)
            {
                Answers.Add(objectsA[i].GetComponent<Image>());
                AnswersText.Add(objectsA[i].GetComponentInChildren<TextMeshProUGUI>());

                objectsA[i].GetComponent<Image>().sprite = Questionsprite[i];
                objectsA[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
                objectsA[i].GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Questionsprite[i].rect.width,Questionsprite[i].rect.height) /size;
            }
        }
        else
        {
            for (int i = 0; i < objectsA.Length; i++)
            {
                Answers.Add(objectsA[i].GetComponent<Image>());
                AnswersText.Add(objectsA[i].GetComponentInChildren<TextMeshProUGUI>());

                objectsA[i].GetComponent<Image>().sprite = Questionsprite[i];
                objectsA[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
                objectsA[i].GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Questionsprite[i].rect.width,Questionsprite[i].rect.height)/size;
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
}
