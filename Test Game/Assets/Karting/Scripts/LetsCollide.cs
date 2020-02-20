using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using TMPro;


public class LetsCollide : MonoBehaviour
{

    public TextMeshProUGUI equation;
    public InputField answer;
    public GameObject kart;

    public Text correctAnswer;

    private int result;

    Rigidbody rg;

     void Start()
     {      
     }
     
     void OnCollisionEnter(Collision collision) {
       
          if(collision.gameObject.tag == "Player")
          {
            answer.characterLimit = 2;
            equation.gameObject.SetActive(true);
            answer.gameObject.SetActive(true);
            answer.ActivateInputField();
            answer.onEndEdit.AddListener(delegate { Submited(); });
            Destroy(GetComponent<BoxCollider>());
            Destroy(GetComponent<MeshRenderer>());
            Debug.Log("sup");
            rg = kart.GetComponent<Rigidbody>();
            rg.constraints = RigidbodyConstraints.FreezeAll;
          }
     }

     private void Submited(){
       result = int.Parse(answer.text);
       Debug.Log(result);
       if (result == int.Parse(correctAnswer.text)){
       equation.gameObject.SetActive(false);
       answer.gameObject.SetActive(false);
       rg.constraints = RigidbodyConstraints.None;
       }
       else{
         answer.placeholder.GetComponent<Text>().text = "Try Again";
         answer.text = "";
         answer.ActivateInputField();
       }
       
     }
 }

