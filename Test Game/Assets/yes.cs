using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using TMPro;
using Object = UnityEngine.Object;
using KartGame;

namespace KartGame.KartSystems


public class yes : MonoBehaviour
{

    public TextMeshProUGUI winText;
    public InputField input;


     void Start()
     {
     }
     
     void OnCollisionEnter(Collision collision) {
          if(collision.gameObject.tag == "Player")
          {
            winText.gameObject.SetActive(true);
            input.gameObject.SetActive(true);
            Destroy(GetComponent<MeshRenderer>());
            Debug.Log("sup");
            KartMovement.acceleration = 0f;
          }
     }
 }

