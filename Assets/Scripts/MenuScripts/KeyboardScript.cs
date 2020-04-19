using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyboardScript : MonoBehaviour
{
    public char letter;
    public TextMeshProUGUI inputField;

    public void Keypress()
    {
        inputField.text += letter;
    }

}
