using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyBindBox : MonoBehaviour
{
    InputManager inputManager;
    public GameObject keyItemPrefab;
    public GameObject keyList;
    string buttonToRebind = null;
    Dictionary<string, Text> buttonLabel;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
        string[] buttoNames = inputManager.GetButtonNames();
        buttonLabel = new Dictionary<string, Text>();

        for(int i=0; i<buttoNames.Length;i++)
        {
            string bn;
            bn = buttoNames[i];

            GameObject go = (GameObject)Instantiate(keyItemPrefab);
            go.transform.SetParent(keyList.transform);

            Text buttonNameText = go.transform.Find("Button Name").GetComponent<Text>();
            buttonNameText.text = bn;
            

            Text keyNameText = go.transform.Find("Button/Key Name").GetComponent<Text>();
            keyNameText.text = inputManager.GetKeyNameForButton(bn);
            buttonLabel[bn] = keyNameText;

            Button keyBindButton = go.transform.Find("Button").GetComponent<Button>();
            keyBindButton.onClick.AddListener( ()=> { StartRebindFor(bn); });
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonToRebind != null)
        {
            if(Input.anyKeyDown)
            {
                Array keys = Enum.GetValues(typeof(KeyCode));

                foreach(KeyCode kc in keys)
                {
                    if(Input.GetKeyDown(kc))
                    {
                        inputManager.SetButtonForKey(buttonToRebind, kc);
                        buttonLabel[buttonToRebind].text = kc.ToString();
                        buttonToRebind = null;
                        break;
                    }
                }
            }
        }
    }

    void StartRebindFor(string buttonName)
    {
        buttonToRebind = buttonName;
    }
}
