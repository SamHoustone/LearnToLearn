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
    
    public GameObject panel;
    public List<GameObject> Qpics = new List<GameObject>();
    private MemoryMatchController memoryMatchController;
    public TextMeshProUGUI topicname;

    void Awake()
    {
        memoryMatchController = FindObjectOfType<MemoryMatchController>();
        topicname.text = PlayerPrefs.GetString("REFERENCE");
        
        for (int i = 0;i < PlayerPrefs.GetInt("REFERENCENUMBER")*2; i++)
        {
            Qpics.Add(Instantiate(questionprefab,panel.transform));
        }
    }
    private void Start() 
    {
        for (int i = 0;i < PlayerPrefs.GetInt("REFERENCENUMBER")*2; i++)
        {
            Qpics[i].transform.position = memoryMatchController.PlaceHolders[i].transform.position;
            Qpics[i].name = "" + i;
        }
        
    }

}
