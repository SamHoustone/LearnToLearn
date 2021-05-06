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
        PlayerPrefs.SetString("s", "false");
        SceneManager.LoadScene("DragMatch");
    }

    public void FasterBlaster()
    {
        SceneManager.LoadScene("FasterBlaster");
    }

    public void FlashDrill()
    {
        SceneManager.LoadScene("FlashDrill");
    }

    public void Tetris()
    {
        SceneManager.LoadScene("Tetris");
    }

    public void RaiseTheRoof()
    {
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
