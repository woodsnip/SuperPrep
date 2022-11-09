using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InputManager : MonoBehaviour
{
    Dictionary<string, KeyCode> buttonKeys;

    void OnEnable()
    {
        buttonKeys = new Dictionary<string, KeyCode>();

        buttonKeys["Jump"] = KeyCode.Space;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetButtonDown(string buttonName)
    {
        if(buttonKeys.ContainsKey(buttonName)==false)
        {
            Debug.LogError("InputManager::GetButtonDown -- No button named: " + buttonName);
            return false;
        }

        return Input.GetKeyDown(buttonKeys[buttonName]);
    }

    public string[] GetButtonNames()
    {
        return buttonKeys.Keys.ToArray();
    }

    public string GetKeyNameForButton(string buttonName)
    {
        if(buttonKeys.ContainsKey(buttonName)==false)
        {
            return "N/A";
        }
        return buttonKeys[buttonName].ToString();
    }

    public void SetButtonForKey(string buttonName, KeyCode keyCode)
    {
        buttonKeys[buttonName] = keyCode;
    }
}
