using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddShader : MonoBehaviour
{

    private Material matertial;
    public float shift;
    public float red;
    public float fade;

    private void Awake()
    {
       matertial = new Material(Shader.Find("Hidden/Wirl"));
       matertial.SetFloat("_shift", shift);
        matertial.SetFloat("_red", red);
        matertial.SetFloat("_fade", fade);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, matertial);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        matertial.SetFloat("_shift", shift);
        matertial.SetFloat("_red", red);
        matertial.SetFloat("_fade", fade);
    }

}
