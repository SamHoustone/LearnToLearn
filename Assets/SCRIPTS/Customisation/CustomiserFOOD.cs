using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;

public class CustomiserFOOD : MonoBehaviour
{
    private bool on;


    public List<CustomInputField> Q = new List<CustomInputField>();
    public List<CustomInputField> A = new List<CustomInputField>();

    public int number;
    public CustomInputField numberselector;

    public Transform question;
    public GameObject questionprefab;

    public Transform answer;
    public GameObject answerprefab;
    public  void Go()
    {

        number = int.Parse(numberselector.inputText.text);
        PlayerPrefs.SetInt("REFERENCEFOOD", number);


        for (int i = 0; i < number; i++)
        {
            GameObject questionGo = Instantiate(questionprefab);
            questionGo.name = "" + i;
            questionGo.transform.SetParent(question, false);
        }
        for (int i = 0; i < number; i++)
        {
            GameObject questionGo = Instantiate(answerprefab);
            questionGo.name = "" + i;
            questionGo.transform.SetParent(answer, false);
        }

        GameObject[] QT = GameObject.FindGameObjectsWithTag("CusQ");
        GameObject[] AT = GameObject.FindGameObjectsWithTag("CusA");

        for (int i = 0; i < QT.Length; i++)
        {
            Q.Add(QT[i].GetComponent<CustomInputField>());
        }
        for (int i = 0; i < AT.Length; i++)
        {
            A.Add(AT[i].GetComponent<CustomInputField>());
        }
    }

    private void Update()
    {
        number = int.Parse(numberselector.inputText.text);
        PlayerPrefs.SetInt("REFERENCEFOOD", number);

        for (int i = 0; i < number; i++)
        {
            PlayerPrefs.SetString("FOODQ" + i, Q[i].inputText.text);
            PlayerPrefs.SetString("FOODA" + i, A[i].inputText.text);
        }
    }
}
