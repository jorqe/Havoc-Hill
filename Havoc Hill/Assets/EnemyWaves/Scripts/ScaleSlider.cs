using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleSlider : MonoBehaviour
{

    public Slider scaleSlider;

    private float scaleSliderNumber = 1.0f;
    // Update is called once per frame
    void Update()
    {
        scaleSliderNumber = scaleSlider.value;
        Vector3 scale = new Vector3(scaleSliderNumber,scaleSliderNumber,scaleSliderNumber);
        this.transform.localScale = scale;
        
    }
}
