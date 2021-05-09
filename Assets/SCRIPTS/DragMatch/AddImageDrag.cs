using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddImageDrag : MonoBehaviour
{
    public Transform question;
    public Transform answer;

    public GameObject answerprefab;
    public GameObject questionprefab;

    public GameObject answerprefabS;
    public GameObject questionprefabS;

    public TextMeshProUGUI topicname;

    private string one;

    // Start is called before the first frame update
    void Awake()      
    {
        one = PlayerPrefs.GetString("DM");
        topicname.text = PlayerPrefs.GetString("REFERENCE");
        Debug.Log(PlayerPrefs.GetInt("REFERENCENUMBER"));  

        Com();       
    }
    public void Com()
    {
        if (one == "false")
        {
            for (int i = 0; i < PlayerPrefs.GetInt("REFERENCENUMBER"); i++)
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
        if (one == "true")
        {
            for (int i = 0; i < PlayerPrefs.GetInt("REFERENCENUMBER"); i++)
            {
                GameObject questionGo = Instantiate(answerprefabS);
                questionGo.name = "" + i;
                questionGo.transform.SetParent(question, false);
            }
            for (int i = 0; i < PlayerPrefs.GetInt("REFERENCENUMBER"); i++)
            {
                GameObject questionGo = Instantiate(questionprefabS);
                questionGo.name = "" + i;
                questionGo.transform.SetParent(answer, false);
            }
        }
    }
}
