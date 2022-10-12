using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderController : MonoBehaviour {

    Material material;
    float t = 0;
    Vector4 center;

	// Use this for initialization
	void Start () {
        material = GetComponent<SpriteRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        //Effect123456();
        Effect78910();

    }

    void Effect123456()
    {
        //t += 0.002f;
        t += 0.01f;
        material.SetFloat("_TFloat", t);
    }

    void Effect78910()
    {
        //t += 0.002f;
        t += 0.1f;
        material.SetFloat("_TFloat", t);
        center = new Vector4(0.3f, 0.5f, 0, 0);
        material.SetVector("_Center", center);
    }
}
