using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Update is called once per frame
   public void MemoryMatch()
   {
        SceneManager.LoadScene("MemoryMatch");
   }

    public void DragMatch()
    {
        PlayerPrefs.SetString("DM", "false");
        SceneManager.LoadScene("DragMatch");
    }

    public void FasterBlaster()
    {
        SceneManager.LoadScene("FasterBlaster");
    }

    public void FlashDrill()
    {
        PlayerPrefs.SetString("FD", "false");
        SceneManager.LoadScene("FlashDrill");
    }

    public void Tetris()
    {
        SceneManager.LoadScene("Tetris");
    }

    public void RaiseTheRoof()
    {
        PlayerPrefs.SetString("RR", "false");
        SceneManager.LoadScene("RAISETHEROOF");
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("Main Menu (Desktop)");
    }    

    public void Exit ()
    {
        Application.Quit();
    }
}
