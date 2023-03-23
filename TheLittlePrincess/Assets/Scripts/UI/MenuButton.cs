using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;

    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if (Input.GetKeyDown(KeyCode.Return)) {
				animator.SetBool ("pressed", true);
				menuButtonController.PressButton(thisIndex);
			}
			else if (animator.GetBool ("pressed")) {
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}else{
			animator.SetBool ("selected", false);
		}
    }

	public void SetIndex(int index)
    {
		this.thisIndex = index;
    }
}
