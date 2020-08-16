using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnRollDie()
    {
        GameManager.instance.TakeTurn();
    }
}
