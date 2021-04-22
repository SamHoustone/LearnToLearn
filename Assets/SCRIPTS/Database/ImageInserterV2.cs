using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageInserterV2 : MonoBehaviour
{
    public Image image;

    private void Start()
    {
        StartCoroutine(GetImage());
    }


    IEnumerator GetImage()
    {
        WWW wwwImage = new WWW("https://image.shutterstock.com/image-photo/mountains-under-mist-morning-amazing-260nw-1725825019.jpg");
        yield return wwwImage;

        image.material.mainTexture = wwwImage.texture;
        image.enabled = false;
        image.enabled = true;
    }
}
