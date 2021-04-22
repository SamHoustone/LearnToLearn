using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageInserter : MonoBehaviour
{
    public Image image;
    public string imageString = "";

    private void Start()
    {
        StartCoroutine(GetImage());
    }


    IEnumerator GetImage()
    {
        WWWForm imageForm = new WWWForm();
        WWW wwwImage = new WWW("http://localhost/ll/IM.php");
        yield return wwwImage;
        imageString = wwwImage.text;

        byte[] imageBytes = Convert.FromBase64String(imageString);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imageBytes);
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        image.sprite = sprite;
    }
}
