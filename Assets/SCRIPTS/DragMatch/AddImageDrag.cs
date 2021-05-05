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
    public Switch switche;
    // Start is called before the first frame update
    void Awake()
    {
        switche = FindObjectOfType<Switch>();
        topicname.text = PlayerPrefs.GetString("REFERENCE");
        Debug.Log(PlayerPrefs.GetInt("REFERENCENUMBER"));

        Com();       
    }
    public void Com()
    {
        if (PlayerPrefs.GetString("s") == "0")
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
        if (PlayerPrefs.GetString("s") == "1")
        {
            for (int i = 0; i < PlayerPrefs.GetInt("REFERENCENUMBER"); i++)
            {
                GameObject questionGo = Instantiate(questionprefabS);
                questionGo.name = "" + i;
                questionGo.transform.SetParent(answer, false);
            }
            for (int i = 0; i < PlayerPrefs.GetInt("REFERENCENUMBER"); i++)
            {
                GameObject questionGo = Instantiate(answerprefabS);
                questionGo.name = "" + i;
                questionGo.transform.SetParent(question, false);
            }
        }
    }
}
