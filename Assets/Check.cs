using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    private List<GameObject> _carList;
    MemberInfo memberInfo;
   
    private void OnTriggerEnter(Collider other) 
    {

        if (!Comparison(other.gameObject)) 
        {
            _carList.Add(other.gameObject);
            memberInfo = other.GetComponent<MemberInfo>();
            memberInfo.points++;
        }
      
        Debug.Log(other.name);
        Debug.Log(_carList.Count);
        //Debug.Log(memberInfo.time);
    }
    void Start()
    {
        _carList = new List<GameObject>(); //Список машин, проехавших через чекпоинт
    }

    
    void Update()
    {
        
    }

    bool Comparison(GameObject car) // Проверка проехала ли машина через чекпоинт
    {
      
        for (int i = 0; i < _carList.Count; i++) 
        {
            if (car == _carList[i])
            {
                return true;
                
            }
            
        }
        return false;

    }
}

