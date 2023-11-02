using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rainbow : MonoBehaviour
{
    // Start is called before the first frame update

    TextMeshProUGUI textMeshPro;
    int firstVertexIndex;
    int lastVertexIndex;
    void Start()
    {
        Invoke(nameof(DelayedStart),0.3f);
        InvokeRepeating(nameof(ChangeColor), 1f, 0.001f);
    }

    void DelayedStart()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        Debug.Log(textMeshPro.textInfo.characterCount);
        firstVertexIndex = textMeshPro.textInfo.characterInfo[8].vertexIndex;
        lastVertexIndex = textMeshPro.textInfo.characterInfo[11].vertexIndex;
    }

    void ChangeColor()
    {
        for (int i = firstVertexIndex; i <= lastVertexIndex + 3; i++)
            textMeshPro.textInfo.meshInfo[0].colors32[i] = new Color32((byte)(i * 5 * Time.time-100), (byte)(i * 10 * Time.time-100), (byte)(i * 15 * Time.time-100), 255);
        textMeshPro.UpdateVertexData();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
