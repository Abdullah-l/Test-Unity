using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EOL : MonoBehaviour
{
    public TextMeshProUGUI EOLmessage;
    public Text Time;
    void Start()
    {
        EOLmessage.text = "Level 1 Completed!\nTime: " + Time.text;
    }
}
