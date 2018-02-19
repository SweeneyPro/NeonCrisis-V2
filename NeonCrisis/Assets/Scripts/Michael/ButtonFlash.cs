using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFlash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Test()
    {
        StartCoroutine("Flash");
    }

    IEnumerator Flash()
    {
        GetComponent<Image>().material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Image>().material.SetFloat("_FlashAmount", 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Image>().material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Image>().material.SetFloat("_FlashAmount", 0);
    }
}
