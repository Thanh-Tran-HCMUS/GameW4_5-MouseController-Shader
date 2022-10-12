using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    [SerializeField]
    float zoomFactor = 1.0f;

    [SerializeField]
    float zoomSpeed = 5.0f;

    [SerializeField]
    float zoomperClick = 1.0f;

    private float originalSize = 0f;

    private Camera thisCamera;

    // Use this for initialization
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        originalSize = thisCamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SetZoom(zoomFactor += zoomperClick);

        if (Input.GetMouseButtonDown(1))
            SetZoom(zoomFactor -= zoomperClick);

        float targetSize = originalSize * zoomFactor;
        if (targetSize != thisCamera.orthographicSize)
        {
            thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize,
    targetSize, Time.deltaTime * zoomSpeed);
        }
    }

    void SetZoom(float zoomFactor)
    {
        this.zoomFactor = zoomFactor;
    }
}
