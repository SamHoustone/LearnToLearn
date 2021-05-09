using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchFD : MonoBehaviour
{
    public Animator Q;
    public Animator A;

    public string one;

    public bool isSwitch;
    // Start is called before the first frame update
    public void SwitchON()
    {
        one = PlayerPrefs.GetString("FD");

        if (one == "true")
        {
            PlayerPrefs.SetString("FD", "false");
            isSwitch = true;
            Debug.Log("NICE2");
            SceneManager.LoadScene("Ra");

        }
        if (one == "false")
        {
            PlayerPrefs.SetString("FD", "true");
            isSwitch = false;
            Debug.Log("NICE");
            SceneManager.LoadScene("FlashDrill");
        }

    }
    // Update is called once per frame
    void Update()
    {
        one = PlayerPrefs.GetString("FD");

        Debug.Log(PlayerPrefs.GetString("FD"));
        if (one == "true")
        {
            A.Play("A2");
        }
        else
        {
            A.Play("A");
        }
    }
}
