using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] correct;
    public AudioClip[] wrong;

    public AudioSource audioSource;
    public AudioListener audioListener;
    private FlashDrillController flashDrillController;

    // Start is called before the first frame update
    void Start()
    {
        flashDrillController = FindObjectOfType<Canvas>().GetComponent<FlashDrillController>();
        audioListener = GetComponent<AudioListener>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Correct()
    {
        audioSource.clip = correct[Random.Range(0, correct.Length)];
        audioSource.Play();
    }
    public void Wrong()
    {
        audioSource.clip = wrong[Random.Range(0, wrong.Length)];
        audioSource.Play();
    }
}
