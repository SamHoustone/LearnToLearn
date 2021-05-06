using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public Animator Q;
    public Animator A;

    public string one;

    public bool isSwitch;
    // Start is called before the first frame update
    public void SwitchON()
    {

        if (one == "true")
        {
            PlayerPrefs.SetString("s", "false");
            isSwitch = true;
            Debug.Log("NICE2");
            SceneManager.LoadScene("DragMatch");

        }
        if (one == "false")
        {
            PlayerPrefs.SetString("s", "true");
            isSwitch = false;
            Debug.Log("NICE");
            SceneManager.LoadScene("DragMatch");
        }

    }
    // Update is called once per frame
    void Update()
    {
        one = PlayerPrefs.GetString("s");

        Debug.Log(PlayerPrefs.GetString("s"));
        if (one == "true")
        {
            Q.Play("SwitchQ");
            A.Play("SwitchA");
        }
        else
        {
            Q.Play("SwitchQ2");
            A.Play("SwitchA2    ");
        }    
    }
}
