using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.InitializeNewLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
