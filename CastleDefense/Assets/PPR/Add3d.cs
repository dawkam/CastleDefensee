using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add3d : MonoBehaviour
{
    private Material material;
    [Range(0, 1)]public float intensity;
    void Awake()
    {
        material = new Material(Shader.Find("Hidden/3d"));

    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetFloat("_intensity", intensity);
        Graphics.Blit(source, destination, material);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
