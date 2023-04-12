using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DonnerEnigme : MonoBehaviour
{
    public TextMeshProUGUI display;
    public TextMeshProUGUI globalText;

    bool active = false;

    int riddleNb = 0;

    bool solved = false;

    public bool IsSolved()
    {
        return solved;
    }

    void Start()
    {
        
    }


    void OnTriggerEnter(Collider go)

    {
        globalText.text = "";

        if (go.CompareTag("Princesse"))
        {
            this.active = true;

            if(!solved) StartCoroutine(PauseForIntro());

           
        }
    }

    IEnumerator PauseForIntro()
    {
        DoAction("Princesse, il est maintenant temps de r�pondre � ces 3 �nigmes pour sortir de cette plan�te ");

        yield return new WaitForSeconds(2);

        DoAction("Etes-vous pr�te ? (Appuyer sur Y)");
    }

    IEnumerator PauseForRidle(string intro, string riddle, string choices)
    {
        DoAction(intro);

        yield return new WaitForSeconds(4);

        DoAction(riddle);

        yield return new WaitForSeconds(10);

        DoAction(choices);

        
    }



    void Update()
    {
       

        if (this.active == true && !solved)

        {
            globalText.text = "";
            if (Input.GetKeyDown(KeyCode.Y))
            {
               
                StartCoroutine(PauseForRidle("C'est parti ! Voici la premi�re �nigme","Quand on y est, on ne sait o� on est. \n\n Il n�est fait que d�eau, mais peut devenir un imp�n�trable rideau. \n\n Quelle est la r�ponse ?", "a. Le brouillard \n\n b. La pluie\n\n c. La rivi�re"));
                riddleNb++;

            }

            else if (Input.GetKeyDown(KeyCode.A) && riddleNb == 1)
            {
                StartCoroutine(PauseForRidle("Super ! Passons � la prochaine �nigme", "Plac�es contre les yeux, elles permettent le rapprochement \n\n Si toujours elles sont deux, elles se ressemblent assur�ment. \n\n Qui sont-elles ?", "a. Les lunettes\n\n b. Les yeux\n\n c. Les jumelles\n\n"));
                riddleNb++;
            }
            else if (Input.GetKeyDown(KeyCode.C) && riddleNb == 2)
            {
                StartCoroutine(PauseForRidle("Incroyable ! Saurez-vous r�soudre la derni�re ?", "Je commence la nuit, je finis le matin.\n\n Je suis dans l'�tang \n\n Je suis dans le jardin \n\n Et je passe deux fois dans l'ann�e. \n\n Qui suis-je ?", "a. L'aube \n\n b. La lettre N \n\n c. L'eau"));
                riddleNb++;
            }
            else if (Input.GetKeyDown(KeyCode.B) && riddleNb == 3)
            {
                display.color = Color.yellow;
                DoAction("F�licitations vous avez termin� cette plan�te :)");
                this.solved = true;
            }
            
        }
            
    }

    void DoAction(string txt)
    {
        display.text = txt;
        display.color = new Color(1f, 0.5f, 0f, 1f);
    }
}

