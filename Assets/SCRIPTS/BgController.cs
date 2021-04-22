using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgController : MonoBehaviour
{
    public Sprite[] image;
    private Image imagecomponent;
    // Start is called before the first frame update
    void Start()
    {
        imagecomponent = GetComponent<Image>();
        imagecomponent.sprite = image[Random.Range(0, image.Length)];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
