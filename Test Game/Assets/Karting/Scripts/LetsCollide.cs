using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using TMPro;

namespace KartGame.KartSystems
{
    public class LetsCollide : MonoBehaviour
    {

        public TextMeshProUGUI equation;
        public InputField answer;
        public GameObject kart;

        public Text correctAnswer;

        private int result;

        private KartMovement km;
        private KartAnimation ka;

        public Text cubes;
        private CubeCounter cs;

        public GameObject EOLcanvas;

        GameObject timer;

        void Start()
        {
            cs = kart.GetComponent<CubeCounter>();
        }

        void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.tag == "Player")
            {
                answer.characterLimit = 2;
                equation.gameObject.SetActive(true);
                answer.gameObject.SetActive(true);
                answer.ActivateInputField();
                Destroy(GetComponent<BoxCollider>());
                Destroy(GetComponent<MeshRenderer>());
                km = kart.GetComponent<KartMovement>();
                ka = kart.GetComponent<KartAnimation>();
                km.enabled = !km.enabled;
                ka.enabled = !ka.enabled;
                answer.onEndEdit.AddListener(delegate { Submited(); });
            }
        }

        private void Submited()
        {
            result = int.Parse(answer.text);
            Debug.Log(result);
            if (result == int.Parse(correctAnswer.text))
            {
                equation.gameObject.SetActive(false);
                answer.gameObject.SetActive(false);
                km.enabled = !km.enabled;
                ka.enabled = !ka.enabled;
                cubes.text = "Cubes left: " + cs.i + "/10";
                if (cs.i == 0)
                {
                    km.enabled = false;
                    ka.enabled = false;
                    Debug.Log("it is 9");
                    //EOLcanvas = GameObject.Find("EndOfLevel");
                    EOLcanvas.SetActive(true);
                    timer = GameObject.Find("Time");
                    timer.SetActive(false);
                }
            }
            else
            {
                answer.placeholder.GetComponent<Text>().text = "Try Again";
                answer.text = "";
                answer.ActivateInputField();
            }

        }
    }

}