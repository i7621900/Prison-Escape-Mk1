using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

    public string nextLevel; 

    void OnTriggerEnter2D()
    {
        Application.LoadLevel(nextLevel);
    }
}
