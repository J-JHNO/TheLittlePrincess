using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecupererIndices : MonoBehaviour
{
    

    public TextMeshProUGUI display;

    public GameObject tower;

    public PlayerController playerController;


    int n = 0;

    int nbIndices = 5;

    bool found1 = false;
    bool found2 = false;
    bool found3 = false;
    bool found4 = false;
    bool found5 = false;

    bool finished = false;

    bool inside = true;

    bool start = false;

    IEnumerator Ending()
    {

        yield return new WaitForSeconds(2);

        display.text = "Félicitations vous avez trouvé tous les indices ! \n\n Dirigez vous vers la tour centrale pour rencontrer le Père Fouras et résoudre les énigmes ";
        display.color = Color.red;
        yield return new WaitForSeconds(3);
    }

    void Start()
    {
        display.text = "Bienvenue dans la planète du Père Fouras ! \n\n Les règles pour en sortir sont simples, il vous faudra gravir les marches de la tour et résoudre les 3 énigmes. \n\n Dans l'enceinte du chateau sont situés des habitants qui vous délivreront des indices pour vous aider dans votre quête, allez d'abord les rencontrer.";
        start = true;
        AudioSource musicSource = GetComponent<AudioSource>(); 
        
        if(musicSource != null) musicSource.Play(); 
    }

    void OnTriggerEnter(Collider go)

    {
        
       if(n == nbIndices && !finished)
       {
            StartCoroutine(Ending());
            this.finished = true;
       }

       if (go.CompareTag("Elf_1"))
        {
            if (!found1)
            {
                n++;
                found1 = true;
            }
            display.text = "Indice 1 :La brume est un phénomène qui se produit lorsque l'air est saturé d'humidité. Elle peut parfois donner l'impression que tout est enveloppé dans une couverture blanche et mystérieuse \n\n Indices trouvés : " + n+" / 5 ";
        }

        else if (go.CompareTag("Elf_2"))
        {
            if (!found2)
            {
                n++;
                found2 = true;
            }
            display.text = "Indice 2 :  Deux frères nés ensemble, partageant des traits physiques similaires sont appelés des jumeaux. \n\n Indices trouvés : " + n + " / 5 ";
        }

        else if (go.CompareTag("Guerrier_1"))
        {
            if (!found3)
            {
                n++;
                found3 = true;
            }
            display.text = "Indice 3 :  La plupart des langues possèdent un ouvrage contenant des mots et leurs définitions, ainsi que des informations sur l'orthographe, la prononciation, l'étymologie et parfois même des exemples d'utilisation\n\n Indices trouvés : " + n + " / 5 ";
        }

        else if (go.CompareTag("Guerrier_2"))
        {
            if (!found4)
            {
                n++;
                found4 = true;
            }
            display.text = "Indice 4 :  Les rats, les souris, les hamsters, les écureuils et les castors sont des animaux faisant partie de la famille des rongeurs. \n\n Indices trouvés : " + n + " / 5 ";
        }

        else if (go.CompareTag("Guerrier_3"))
        {
            if (!found5)
            {
                n++;
                found5 = true;
            }
            display.text = "Indice 5 :  L'alphabet français comporte 26 lettres. : " + n + " / 5 ";
        }
        if(!go.CompareTag("Elf_1") && !go.CompareTag("Elf_2") && !go.CompareTag("Guerrier_1") && !go.CompareTag("Guerrier_2") && !go.CompareTag("Guerrier_3") && !start)
        {
            display.text = "";
        }
        if (go.CompareTag("Tower_entry"))
        {
            tower.SetActive(!inside);
            inside = !inside;
        }
      
    }
}
