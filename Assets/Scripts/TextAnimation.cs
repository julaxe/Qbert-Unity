using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimation : MonoBehaviour
{
    private TMP_Text text;
    private VertexGradient gradient;
    public Color color1;
    public Color color2;
    private Color lerpColor1;
    private Color lerpColor2;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();

        lerpColor1 = color1;
        lerpColor2 = color2;
    }

    // Update is called once per frame
    void Update()
    {
        lerpColor1 = Color.Lerp(color1, color2, Mathf.Sin(Time.time * 18));
        lerpColor2 = Color.Lerp(color1, color2, Mathf.Cos(Time.time * 18));

        gradient = new VertexGradient(lerpColor1, lerpColor1, lerpColor2, lerpColor2);
   
        text.colorGradient = gradient;
    
    }
}
