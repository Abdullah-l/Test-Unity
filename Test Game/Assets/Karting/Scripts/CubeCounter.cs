using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;


public class CubeCounter : MonoBehaviour
{
    public Text cubes;
    private int i = 10;
     void Start()
     {      
     }
     
     void OnCollisionEnter(Collision collision) {
       
          if(collision.gameObject.tag == "Cube")
          {
            i--;
            Debug.Log("hit cube");
            cubes.text = "Cubes left: " + i + "/10";
          }
     }
 }

