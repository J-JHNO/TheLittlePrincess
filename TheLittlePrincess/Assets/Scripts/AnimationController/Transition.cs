using System.Collections;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private new Animator animation;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    public void Walk(bool playAnim)
    {
        animation.SetBool("walk", playAnim);
    }

    public void Run(bool playAnim)
    {
        animation.SetBool("run", playAnim);
    }

    public void Crouch(bool playAnim)
    {
        animation.SetBool("crouch", playAnim);
    }

    public void Jump(bool playAnim)
    {
        animation.SetBool("jump", playAnim);
    }

}
