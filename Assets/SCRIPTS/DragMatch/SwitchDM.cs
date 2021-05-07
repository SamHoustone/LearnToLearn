using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchDM : MonoBehaviour
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
            PlayerPrefs.SetString("DM", "false");
            isSwitch = true;
            SceneManager.LoadScene("DragMatch");

        }
        if (one == "false")
        {
            PlayerPrefs.SetString("DM", "true");
            isSwitch = false;
            SceneManager.LoadScene("DragMatch");
        }

    }
    // Update is called once per frame
    void Update()
    {
        one = PlayerPrefs.GetString("DM");

        Debug.Log(PlayerPrefs.GetString("DM"));
        if (one == "true")
        {
            Q.Play("SwitchQ");
            A.Play("SwitchA");
        }
        else
        {
            Q.Play("SwitchQ2");
            A.Play("SwitchA2");
        }    
    }
}
