using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    private Camera cam;
    private BoxCollider2D bc2d; // Camera's collider
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float sizeY = cam.orthographicSize * 2;
        float ratio = (float) Screen.width / (float) Screen.height;
        float sizeX = sizeY * ratio;

        bc2d.size = new Vector2(sizeX, sizeY);
    }
}
