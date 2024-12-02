using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberInfo : MonoBehaviour
{
   
    public string memberName;
    public int points;
    public int count;
    public float time;
    public bool race;
  
    public PlayerGhostData playerGhostData;
    public Transform transfor;
    public GameObject parent;

    void Start()
    {
        transfor = parent.GetComponent<Transform>();
        count = points;
        
    }

    
    void Update()
    {
        if (race)
        {
            time = 0;
            race = false;
        }    
        if (count != points) 
        {
            count++;
        }
        time = Time.time;

        
    }

    
}
