using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAnimationControler : MonoBehaviour
{
    Rigidbody2D currentRigidbody;
    GameObject alienFlipObject;

    Vector3 position = Vector3.zero, previusPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        currentRigidbody = GetComponent<Rigidbody2D>();
        alienFlipObject = transform.Find("Flipable").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        previusPosition = position;
        position = transform.position;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Sign( position.x - previusPosition.x);

        alienFlipObject.transform.localScale = scale;
    }
}
