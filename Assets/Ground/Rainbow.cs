using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    private Material tunnelMaterial;
    private float colorOffset;

    public float tone = 1f;
    public float colorChangeSpeed = 0.1f;
    private void Start()
    {
        tunnelMaterial = GetComponent<Renderer>().material;
        colorOffset = Random.Range(0f, 1f);
    }
    private void Update()
    {
        float t = Mathf.PingPong(Time.time * colorChangeSpeed + colorOffset, 1.0f);
        tunnelMaterial.color = Color.HSVToRGB(t, tone, 1.0f);
    }
}
