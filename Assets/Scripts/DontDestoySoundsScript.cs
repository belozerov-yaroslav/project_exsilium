using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoySoundsScript : MonoBehaviour
{
    private static bool _isExist;
    private void Awake()
    {
        if (!_isExist)
        {
            _isExist = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }     
       
    }

}
