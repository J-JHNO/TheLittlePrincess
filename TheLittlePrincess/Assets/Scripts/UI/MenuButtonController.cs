using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour {

	// Use this for initialization
	public string context = "menuName";
	public bool _isActive = true;

	public int index;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;

	public AudioSource audioSource;
	public MenuController menuController;
	
	// Update is called once per frame
	void Update () {
		if (!_isActive) return;
		if (Input.GetAxis ("Vertical") != 0) {
			if (!keyDown) {
				if (Input.GetAxis ("Vertical") < 0) {
					if (index < maxIndex) {
						index++;
					} else{
						index = 0;
					}
				} else if (Input.GetAxis ("Vertical") > 0) {
					if (index > 0) {
						index --; 
					} else {
						index = maxIndex;
					}
				}
				keyDown = true;
			}
		}else{
			keyDown = false;
		}
	}

	public void PressButton(int indexButton)
    {
		menuController.PressButton(indexButton, context);
	}

	public void Activate()
    {
		_isActive = true;
		index = 0;
		UpdateUI(_isActive);
	}

	public void DeActivate()
    {
		_isActive = false;
		UpdateUI(_isActive);
	}

	public void UpdateUI(bool show)
    {
		this.gameObject.SetActive(show);
	}

}
