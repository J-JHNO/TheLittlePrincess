using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMenuController : MonoBehaviour
{
    public abstract void PressButton(int indexButton, string context);
}
