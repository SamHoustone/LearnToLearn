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
    public List<Transform> PlaceHolders = new List<Transform>();

    private bool firstGuess = false, secondGuess = false;
    private int FirstGameIndex, SecondGameIndex;
    private Image firstGuessName, secondGuessName;

    private bool cantouch;
    private AddImage addImage;

    public List<string> spriteQ = new List<string>();
    public List<Sprite> images = new List<Sprite>();

    public ScoreCoinAnima scoreCoinAnima;

    public List<Button> btnsQ = new List<Button>();
    public Transform Logo;
    public int size;
    public Animator animator;
    private Score score;
    private AudioManager audioManager;

    private int reference2;
    private string reference;
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


        ImageQ[0] = spriteQ1;
        ImageQ[1] = spriteQ2;
        ImageQ[2] = spriteQ3;
        ImageQ[3] = spriteQ4;
        ImageQ[4] = spriteQ5;
        ImageQ[5] = spriteQ6;
        ImageQ[6] = spriteQ7;
        ImageQ[7] = spriteQ8;

        ImageA[0] = spriteQ1;
        ImageA[1] = spriteQ2;
        ImageA[2] = spriteQ3;
        ImageA[3] = spriteQ4;
        ImageA[4] = spriteQ5;
        ImageA[5] = spriteQ6;
        ImageA[6] = spriteQ7;
        ImageA[7] = spriteQ8;

        for (int i = 0; i < reference2; i++)
        {
            ImageQ[i].name = i.ToString();
            ImageA[i].name = i.ToString();
        }
        Go2();
    }
    private void Update() 
    {
      PlaceHolders[0].transform.position = addImage.Qpics[0].transform.position;
      PlaceHolders[1].transform.position = addImage.Qpics[1].transform.position;
      PlaceHolders[2].transform.position = addImage.Qpics[2].transform.position;
      PlaceHolders[3].transform.position = addImage.Qpics[3].transform.position;
      PlaceHolders[4].transform.position = addImage.Qpics[4].transform.position;
      PlaceHolders[5].transform.position = addImage.Qpics[5].transform.position;
      PlaceHolders[6].transform.position = addImage.Qpics[6].transform.position;
      PlaceHolders[7].transform.position = addImage.Qpics[7].transform.position;
      PlaceHolders[8].transform.position = addImage.Qpics[8].transform.position;
      PlaceHolders[9].transform.position = addImage.Qpics[9].transform.position;
      PlaceHolders[10].transform.position = addImage.Qpics[10].transform.position;
      PlaceHolders[11].transform.position = addImage.Qpics[11].transform.position;
      PlaceHolders[12].transform.position = addImage.Qpics[12].transform.position;
      PlaceHolders[13].transform.position = addImage.Qpics[13].transform.position;
      PlaceHolders[14].transform.position = addImage.Qpics[14].transform.position;
      PlaceHolders[15].transform.position = addImage.Qpics[15].transform.position;
    }
    public void Go2()
    {
        AddgamePuzzle();
        Shuffle(spriteQ, images,PlaceHolders);
        GetButtonsQ();
        AddListners();

        for (int i = 0; i < reference2 * 2; i++)
        {
            btnsQ[i].GetComponent<Image>().sprite = images[i];
            StartCoroutine(BackToNormal());
        }
    }
    public void Start()
    {
        StartCoroutine(GO());
        reference = PlayerPrefs.GetString("REFERENCE");
        reference2 = PlayerPrefs.GetInt("REFERENCENUMBER");
        cantouch = false;
        audioManager = FindObjectOfType<Camera>().GetComponent<AudioManager>();
        score = GetComponent<Score>(); 
        addImage = FindObjectOfType<AddImage>();               
    }
    IEnumerator BackToNormal()
    {
        yield return new WaitForSeconds(5);
        for (int i = 0; i < reference2*2; i++)
        {
            btnsQ[i].image.sprite = bgImage;
            btnsQ[i].image.rectTransform.sizeDelta = new Vector2(bgImage.rect.width,bgImage.rect.height)/10;
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
            objectsQ[i].GetComponent<Image>().rectTransform.sizeDelta = new Vector2(images[i].rect.width,images[i].rect.height)/size;
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
                audioManager.Tap();
                firstGuess = true;
                FirstGameIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
                firstGuessName = btnsQ[FirstGameIndex].GetComponent<Image>();
                btnsQ[FirstGameIndex].GetComponent<Image>().sprite = images[FirstGameIndex];
                btnsQ[FirstGameIndex].interactable = false;
                btnsQ[FirstGameIndex].GetComponent<Animator>().Play("QuestionAnim");
                
                btnsQ[FirstGameIndex].GetComponent<Image>().rectTransform.sizeDelta = new Vector2(images[FirstGameIndex].rect.width,images[FirstGameIndex].rect.height)/size;
            }
            else if (!secondGuess)
            {
                audioManager.Tap();
                secondGuess = true;
                SecondGameIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
                secondGuessName = btnsQ[SecondGameIndex].GetComponent<Image>();
                btnsQ[SecondGameIndex].GetComponent<Image>().sprite = images[SecondGameIndex];
                StartCoroutine(CheckIfTheGameIsFinished());
                btnsQ[SecondGameIndex].GetComponent<Animator>().Play("QuestionAnim");

                btnsQ[SecondGameIndex].GetComponent<Image>().rectTransform.sizeDelta = new Vector2(images[SecondGameIndex].rect.width,images[SecondGameIndex].rect.height)/size;
                
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

            btnsQ[FirstGameIndex].image.color = new Color(0, 0, 0, 0);
            PlaceHolders[FirstGameIndex].GetComponent<RawImage>().color = new Color(0,0,0,0);
            btnsQ[SecondGameIndex].image.color = new Color(0, 0, 0, 0);
            PlaceHolders[SecondGameIndex].GetComponent<RawImage>().color = new Color(0,0,0,0);

            score.correctint++;

            audioManager.Correct();

            scoreCoinAnima.correct();
        }
        else
        {
            btnsQ[FirstGameIndex].GetComponent<Image>().sprite = bgImage;
            btnsQ[SecondGameIndex].GetComponent<Image>().sprite = bgImage;
            btnsQ[FirstGameIndex].interactable = true;
            score.Cal();
            audioManager.Wrong();
            score.wrongint++;
            scoreCoinAnima.Wrong();

            btnsQ[FirstGameIndex].image.rectTransform.sizeDelta = new Vector2(bgImage.rect.width,bgImage.rect.height)/10;
            btnsQ[SecondGameIndex].image.rectTransform.sizeDelta = new Vector2(bgImage.rect.width,bgImage.rect.height)/10;

        }
        score.attemps++;
        score.Cal();

        firstGuess = secondGuess = false;
    }

    void Shuffle (List<string> list,List<Sprite> list2,List<Transform> list3)
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

            Transform temp3 = list3[i];
            list3[i] = list3[randomIndex];
            list3[randomIndex] = temp3;
        }
    }
   

}
