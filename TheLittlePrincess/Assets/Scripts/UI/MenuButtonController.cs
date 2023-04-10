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
	public IMenuController menuController;
	
	// Update is called once per frame
	void Update () {
		if (!_isActive) return;
		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)) {
			if (!keyDown) {
				if (Input.GetKeyDown(KeyCode.DownArrow)) {
                    if (index < maxIndex) {
						index++;
					} else{
						index = 0;
					}
				} else if (Input.GetKeyDown(KeyCode.UpArrow)) {
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

	public void SetMaxIndex(int maxIndex)
    {
		this.maxIndex = maxIndex;
    }

}
