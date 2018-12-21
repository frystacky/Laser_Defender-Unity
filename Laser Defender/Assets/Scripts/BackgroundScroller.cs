using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    //config param's
    [SerializeField] float backgroundScrollingSpeed = 0.5f;
    Material myMaterial;
    Vector2 offSet;

	// Use this for initialization
	void Start () {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0, backgroundScrollingSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
	}
}
