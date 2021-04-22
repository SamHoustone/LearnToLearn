using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;

public class Score : MonoBehaviour
{
    public bool FirstMove = false;

    public float attemps = 0f;
    public int correctint = 0;
    public float wrongint = 0f;

    public float correctper = 0;
    public float wrongper = 0;

    public ProgressBar ProgressBarCorrect;
    public ProgressBar ProgressBarWrong;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (correctint == PlayerPrefs.GetInt("REFERENCENUMBER"))
        {
            animator.Play("Fade-in");
        }

        ProgressBarCorrect.specifiedValue = correctper;
        ProgressBarWrong.specifiedValue = wrongper;

        ProgressBarCorrect.currentPercent = correctper;
        ProgressBarWrong.currentPercent = wrongper;
    }

    public void Cal ()
    {
        correctper = correctint / attemps * 100;
        wrongper = wrongint / attemps * 100;
    }

}
