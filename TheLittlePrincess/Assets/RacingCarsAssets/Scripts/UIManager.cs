using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void UpdateText(string message)
    {
        text.text = message;
    }
}
