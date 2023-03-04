using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;



public class ClipBoard : MonoBehaviour
{
    private Array _ArrayObject = new String[] {"Montre",
        "AirPods",
        "Telephone",
        "Ordinateur",
        "Tablette",
        "Bouteilles",
        "Cigare",
        "Bijoux",
        "Google Home",
        "Vase",
        "Tableaux",
        "Trophee",
        "Telecomande",
        "Console",
        "Jeux",
        "Chandelier",
        "Couvert de luxe",
        "Lampe",
        "Clef USB",
        "Poisson",
        "Chat"
        
    };


    private String[] _selected = new String[8];
    private int[] _selectedInt = new int[8];

    [SerializeField] private List<TextMeshPro> tasks;

    
    // Start is called before the first frame update
    void Start()
    {
        GenerationTask();
        int i = 0;
        foreach (var task in tasks)
        {
            task.text = _selected[i];
            i += 1;
        }
       

    }

    // Update is called once per frame
    

    private void GenerationTask()
    {
        Random rand = new Random();
        int num;
        for (int i=0; i < _selected.Length; i++)
        {
            do {
                num = rand.Next(0, 8);
            } while (Array.IndexOf(_selected,(String) _ArrayObject.GetValue(num)) != -1);
            _selected[i] = (String) _ArrayObject.GetValue(num);
            _selectedInt[i] = num;

        }
    }
}
