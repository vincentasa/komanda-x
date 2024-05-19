using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Init : MonoBehaviour
{ 
    public void Start()
    {
        gameObject.GetComponent<ViewManager>().PlayScene("mainMenu");
    }

}
