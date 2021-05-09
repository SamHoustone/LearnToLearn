using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FasterBlasterDown : MonoBehaviour
{
    public float speed;
    private Vector3 startPos;
    private float increaseSpeed = -0.0005f;
    public Animator animator;
    public int speedint;
    public TextMeshProUGUI speedtext;
    private FasterBlasterController fasterBlasterController;
    private QGiver qGiver;
    // Start is called before the first frame update
    void Start()
    {
        qGiver = FindObjectOfType<QGiver>();
        fasterBlasterController = FindObjectOfType<Canvas>().GetComponent<FasterBlasterController>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        speedtext = qGiver.GetComponent<TextMeshProUGUI>();
        speedtext.text = speedint.ToString();
        transform.position = transform.position + new Vector3(0, speed, 0);   
    }

    public void CorrectOrWrong()
    {
        speedint++;
        transform.position = startPos;
        speed = speed + increaseSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("TD"))
        {
            CorrectOrWrong();
            fasterBlasterController.Go2();
        }
    }
}
