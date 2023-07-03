using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foamManager : MonoBehaviour
{
    [SerializeField]
    private GameObject foam;
    
    public void showFoam() 
    { 
        this.foam.gameObject.SetActive(true);
    }
    
    public void hideFoam() 
    {
        this.foam.gameObject.SetActive(false);
    }
}
