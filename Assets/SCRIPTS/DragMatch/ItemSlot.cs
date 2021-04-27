using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour ,IDropHandler
{
    private Score score;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<Camera>().GetComponent<AudioManager>();
        score = FindObjectOfType<Canvas>().GetComponent<Score>();
    }

   public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.GetComponent<Image>().sprite.name == GetComponent<Image>().sprite.name)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().gameObject.SetActive(false);
            score.correctint++;
            audioManager.Correct();
            GetComponent<Animator>().Play("QuestionAnim");
        }
        else
        {
            eventData.pointerDrag.GetComponent<Transform>().position = eventData.pointerDrag.GetComponent<DragAndDrop>().startPos;
            score.wrongint++;
            audioManager.Wrong();
            GetComponent<Animator>().Play("QuestionAnim");
        }

        score.attemps++;
        score.Cal();
    }
}