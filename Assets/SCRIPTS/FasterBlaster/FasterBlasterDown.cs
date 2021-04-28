using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterBlasterDown : MonoBehaviour
{
    public float speed;
    private Vector3 startPos;
    private float increaseSpeed = -0.0005f;
    public Animator animator;
    private FasterBlasterController fasterBlasterController;
    // Start is called before the first frame update
    void Start()
    {
        fasterBlasterController = FindObjectOfType<Canvas>().GetComponent<FasterBlasterController>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, speed, 0);   
    }

    public void CorrectOrWrong()
    {
        transform.position = startPos;
        speed = speed + increaseSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("TD"))
        {
            CorrectOrWrong();
            fasterBlasterController.Go2();
            animator.Play("Fade-in");
        }
    }
}
