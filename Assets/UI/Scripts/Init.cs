using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class Init : MonoBehaviour
{ 
    public void Start()
    {
        gameObject.GetComponent<ViewManager>().PlayScene("mainMenu");
    }

}
