using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = System.Random;



public class ClipBoard : MonoBehaviour
{
    private Array _ArrayObject = new String[] {"Apple Watch",
        "Google Hoem",
        "Micro-Ondes",
        "Verres a shots",
        "Tableau",
        "Chat",
        "Trophee",
        "Air Pods",
        "Manette",
        "Stereo",
        "Soda Stream",
        "Bijoux",
        "Cigarres",
        "Carrafe",
        "Porte Manteaux",
        "Lampe"
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
                num = rand.Next(0, _ArrayObject.Length);
            } while (Array.IndexOf(_selected,(String) _ArrayObject.GetValue(num)) != -1);
            _selected[i] = (String) _ArrayObject.GetValue(num);
            _selectedInt[i] = num;

        }
    }

    public bool CheckTask(int id)
    {
        if (!_selectedInt.Contains<int>(id))
        {
            return false;
        }
        for (int i = 0; i < _selectedInt.Length; i++)
        {
            if (_selectedInt[i] == id)
            {
                Debug.Log(id);
                tasks[i].fontStyle = FontStyles.Strikethrough;
                return true;
            }
        }
        return true;
    }
    public bool CheckForEasterEgg(int id)
        {
            if (id != 5)
            {
                return false;
            }
            return true;
        }
}
