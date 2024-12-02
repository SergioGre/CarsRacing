using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFinish : MonoBehaviour
{
   
    MemberInfo memberInfo;
    public GameObject controlManager;
    StartController controllerStart;

    private void OnTriggerEnter(Collider other)
    {

       
     
            memberInfo = other.GetComponent<MemberInfo>();
        controllerStart.Finish(memberInfo);
            

        
    }
    void Start()
    {
        controllerStart = controlManager.GetComponent<StartController>();
    }


    void Update()
    {

    }

    
}
