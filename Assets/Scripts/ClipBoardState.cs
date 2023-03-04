using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipBoardState : MonoBehaviour
{
    private bool _isOut;
    [SerializeField] private GameObject clipBoard;
   
    public bool IsOut
    {
        get { return _isOut;}
        set { _isOut = value; }
    }
    public void SwitchClipBoard()
    {
        clipBoard.SetActive(IsOut);
    }
}
