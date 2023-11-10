using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPos;

    public Transform cameraTransform;
    public float parallaxFactor;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float reposition = cameraTransform.position.x * (1 - parallaxFactor);
        float distance = cameraTransform.position.x * parallaxFactor;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (reposition > startPos + length)
        {
            startPos += length; 
        }
    }
}
