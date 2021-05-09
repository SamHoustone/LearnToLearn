using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchRR : MonoBehaviour
{
    public Animator Q;
    public Animator A;

    public string one;

    public bool isSwitch;
    // Start is called before the first frame update
    public void SwitchON()
    {
        one = PlayerPrefs.GetString("RR");

        if (one == "true")
        {
            PlayerPrefs.SetString("RR", "false");
            isSwitch = true;
            Debug.Log("NICE2");
            SceneManager.LoadScene("RAISETHEROOF");

        }
        if (one == "false")
        {
            PlayerPrefs.SetString("RR", "true");
            isSwitch = false;
            Debug.Log("NICE");
            SceneManager.LoadScene("RAISETHEROOF");
        }

    }
    // Update is called once per frame
    void Update()
    {
        one = PlayerPrefs.GetString("RR");

        Debug.Log(PlayerPrefs.GetString("RR"));
        if (one == "true")
        {
            A.Play("AS");
        }
        else
        {
            A.Play("A");
        }
    }
}
