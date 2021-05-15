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

    public GameObject answerprefabS;
    public GameObject questionprefabS;
    public GameObject panel;

    private string one;

    public TextMeshProUGUI topicname;
    // Start is called before the first frame update
    void Awake()
    {
        one = PlayerPrefs.GetString("FD");
        topicname.text = PlayerPrefs.GetString("REFERENCE");
        if(one == "true")
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject questionGo = Instantiate(questionprefabS);
                questionGo.name = "" + i;
                questionGo.transform.SetParent(question, false);

            }
            for (int i = 0; i < 8; i++)
            {
                GameObject questionGo = Instantiate(answerprefabS);
                questionGo.name = "" + i;
                questionGo.transform.SetParent(answer, false);
            }
        }
        else
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject questionGo = Instantiate(questionprefab,panel.transform);
                questionGo.name = "" + i;

            }
            for (int i = 0; i < PlayerPrefs.GetInt("REFERENCENUMBER"); i++)
            {
                GameObject questionGo = Instantiate(answerprefab);
                questionGo.name = "" + i;
                questionGo.transform.SetParent(answer, false);
            }
        }
  
    }
}


