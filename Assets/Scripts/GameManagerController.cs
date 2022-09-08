using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerController : MonoBehaviour
{
    public Text balasText;
    private int balas;
    // Start is called before the first frame update
    void Start()
    {
        balas =5;
        PrintBalasInScreen();
    }

    public int Balas(){
        return balas;
    }
   public void PerderBalas(){
    balas -=1;
    PrintBalasInScreen();
   }
   private void PrintBalasInScreen(){
    balasText.text="Balas: "+balas;
   }
}
