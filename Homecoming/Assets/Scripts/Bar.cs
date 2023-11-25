using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bar : MonoBehaviour
{
    [SerializeField][Range(0,1)] private float value = 1f;

    RectTransform scaler;

    // Start is called before the first frame update
    void Start()
    {
        scaler = (RectTransform)GetComponent<RectTransform>().Find("Foreground");
    }

    // Update is called once per frame
    void Update()
    {
        float scale = Mathf.Clamp01(value);
        scaler.localScale = new Vector3(scale, 1, 1);
    }

    public void SetValue(float value)
    {
        if (value <= 1f && value >= 0f){
            this.value = value;
        }
        else
        {
            //throw new ArgumentOutOfRangeException($"value must be in [0, 1] interval. Value was {value}.");
        }
    }

    public bool AddValue(float value)
    {
        this.value += value;
        return this.value <= 1f;
    }

    public void LowerValue(float value)
    {
        this.value -= value;
        Mathf.Clamp01(this.value);
    }
}
