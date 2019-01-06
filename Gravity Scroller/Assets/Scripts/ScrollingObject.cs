using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingObject : MonoBehaviour
{
    public  float scrollX = 0.2f;
    public  float scrollY = 0f;

    void Update()
    {
        float OffsetX = Time.time * scrollX;
        float OffsetY = Time.time * scrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }
}