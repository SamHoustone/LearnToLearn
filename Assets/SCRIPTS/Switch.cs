using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Animator Q;
    public Animator A;

    public bool isSwitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SwitchON()
    {
        if(PlayerPrefs.GetString("s") == "0")
        {
            PlayerPrefs.SetString("s", "1");
        }
        if (PlayerPrefs.GetString("s") == "1")
        {
            PlayerPrefs.SetString("s", "0");
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerPrefs.GetString("s"));
        if (PlayerPrefs.GetString("s") == "1")
        {
            Q.Play("SwitchQ");
            A.Play("SwitchA");
        }
    }
}
