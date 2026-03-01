using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DictionaryExample : MonoBehaviour
{
    private Dictionary<string, float> dictionaryOfFloats = new(); // simplified way of initializing something

    private void Start()
    {
        dictionaryOfFloats.Add("Bogosort", 10.43f);
        dictionaryOfFloats.Add("Pi", 3.14f);
        dictionaryOfFloats.Add("Small", 0.0001f);

        Debug.Log(dictionaryOfFloats["Pi"]); // this will output 3.14
        Debug.Log(dictionaryOfFloats["Bogosort"]); // this will output 10.43
        Debug.Log(dictionaryOfFloats["Small"]); // this will output 0.0001

        if (!dictionaryOfFloats.ContainsKey("Pi"))
        {
            dictionaryOfFloats.Add("Pi", 1.43f); // this line would run, as the key already is containted. Only 1 of each key can exist
        }
    }

}