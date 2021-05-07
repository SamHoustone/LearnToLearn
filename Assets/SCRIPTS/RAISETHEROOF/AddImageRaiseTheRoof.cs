using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddImageRaiseTheRoof : MonoBehaviour
{
    public Transform question;
    public Transform answer;

    public GameObject answerprefab;
    public GameObject questionprefab;

    public GameObject answerprefabS;
    public GameObject questionprefabS;


    private string one;

    public TextMeshProUGUI topicname;
    // Start is called before the first frame update
    void Awake()
    {
        one = PlayerPrefs.GetString("RR");
        topicname.text = PlayerPrefs.GetString("REFERENCE");
        if(one == "false")
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject questionGo = Instantiate(questionprefab);
                questionGo.name = "" + i;
                questionGo.transform.SetParent(question, false);

            }
            for (int i = 0; i < 3; i++)
            {
                GameObject questionGo = Instantiate(answerprefab);
                questionGo.name = "" + i;
                questionGo.transform.SetParent(answer, false);
            }
        }
        else
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject questionGo = Instantiate(questionprefabS);
                questionGo.name = "" + i;
                questionGo.transform.SetParent(question, false);

            }
            for (int i = 0; i < 3; i++)
            {
                GameObject questionGo = Instantiate(answerprefabS);
                questionGo.name = "" + i;
                questionGo.transform.SetParent(answer, false);
            }
        }
        
    }
}
