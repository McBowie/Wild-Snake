using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCycle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Material material;
    [SerializeField] Color color1;
    [SerializeField] Color color2;
    [SerializeField] Shader shader;
    [SerializeField] float speed;



    // Update is called once per frame
    void Update()
    {

        material.SetFloat("_ColorTime1", 0.5f + Mathf.Sin(Time.time * 5)/2);
        material.SetColor("_Color1", new Color((1 + Mathf.Sin(Time.time))/2, (1 + Mathf.Sin(Time.time*2)) / 2, (1 + Mathf.Sin(Time.time*3)) / 2));
    }
}
