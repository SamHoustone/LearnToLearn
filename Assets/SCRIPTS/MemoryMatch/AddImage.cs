using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddImage : MonoBehaviour
{
    [SerializeField]
    private Transform question;

    public GameObject questionprefab;

    public TextMeshProUGUI topicname;

    void Start()
    {
        topicname.text = PlayerPrefs.GetString("REFERENCE");

        for (int i = 0;i < PlayerPrefs.GetInt("REFERENCENUMBER")*2; i++)
        {
            Debug.Log(PlayerPrefs.GetInt("REFERENCENUMBER"));
            GameObject questionGo = Instantiate(questionprefab);
            questionGo.name = "" + i;
            questionGo.transform.SetParent(question, false);
        }
    }


}
