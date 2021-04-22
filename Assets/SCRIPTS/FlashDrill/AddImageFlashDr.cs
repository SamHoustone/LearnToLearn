using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddImageFlashDr : MonoBehaviour
{
    public Transform question;
    public Transform answer;

    public GameObject answerprefab;
    public GameObject questionprefab;

    public TextMeshProUGUI topicname;
    // Start is called before the first frame update
    void Awake()
    {
        topicname.text = PlayerPrefs.GetString("REFERENCE");

        for (int i = 0; i < 1; i++)
        {
            GameObject questionGo = Instantiate(questionprefab);
            questionGo.name = "" + i;
            questionGo.transform.SetParent(question, false);

        }
        for (int i = 0; i < PlayerPrefs.GetInt("REFERENCENUMBER"); i++)
        {
            GameObject questionGo = Instantiate(answerprefab);
            questionGo.name = "" + i;
            questionGo.transform.SetParent(answer, false);
        }
    }
}

