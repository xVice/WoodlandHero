using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignUI : MonoBehaviour
{
    public GameObject Sign;
    public TextMeshProUGUI SignText;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void DisplaySign(string text)
    {
        SignText.text = text;
        Sign.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            DisableSign();
        }
    }

    public void DisableSign()
    {
        Sign.SetActive(false);
    }
}
