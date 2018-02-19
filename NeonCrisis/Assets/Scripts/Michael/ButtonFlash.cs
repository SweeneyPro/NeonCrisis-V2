using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFlash : MonoBehaviour {

    public float flash_speed;
    Material material;
    Image image;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        material = image.material;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(Flash());
        }
	}

    public void Flash_Button()
    {
        StartCoroutine("Flash");
    }

    IEnumerator Flash()
    {
        material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(flash_speed);
        material.SetFloat("_FlashAmount", 0);
        yield return new WaitForSeconds(flash_speed);
        material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(flash_speed);
        material.SetFloat("_FlashAmount", 0);
    }
}
