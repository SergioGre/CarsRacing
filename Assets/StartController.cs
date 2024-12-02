using Ashsvp;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StartController : MonoBehaviour
{
    public List<MemberInfo> members;
    GameObject[] checkPoints;
    public GameObject ghostPrefab;
    private GameObject currentGhost;
    public int circles;
    public PlayerGhostData playerGhostData;
    public Rigidbody rigidbody;
    public Transform player;

    public SimcadeVehicleController simcadeVehicleController;
    public Text timerText;
    public Text circleNum;
    public Text win;

    public bool record;
    bool ghost;
    public bool Race;
    Vector3 Raznitsa;
    float timer = 3;
    public bool finished;

    void Start()
    {
        Race = true;
        checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
        circles = 1;
        Raznitsa = new Vector3(0, 1, 0);
        timer = 3;
        simcadeVehicleController.CanDrive = false;
       

        
    }

    
    void FixedUpdate()
    {
        if (record)
        {
            playerGhostData.positions.Add(player.position);
            playerGhostData.rotations.Add(player.rotation);
        }
        if (circles == 2)
            circleNum.text = "Круг 2: Заезд с призраком";
    }
    private void Update()
    {
        StartTimer();
        if (currentGhost != null)
        {
            if (currentGhost.transform.position == playerGhostData.positions.Last())
            {
                finished = true;
                Debug.Log("Приехал");
            }
        }

    }
    public void Finish(MemberInfo info)
    {
        if (info.points == checkPoints.Length && circles == 1) //При прохождении круга, если это был первый круг, сбрасываем таймер и начинаем круг заного с призраком
        {
            record = false;
            info.points = 0;
            info.count = 0;
            info.time = 0;
            timer = 3;
            circles++;
            player.position = new Vector3(37, 1.2f, 69.41f);
            rigidbody.isKinematic = true;
            simcadeVehicleController.CanDrive = false;
            Race = true ;
            rigidbody.isKinematic = false;
            currentGhost = Instantiate(ghostPrefab);
            
            
        }
        if (info.points == checkPoints.Length && circles == 2)
        {
            if(finished) 
            {
                win.color = Color.green;
                win.text = "Победа";
            }
            else 
            {
                win.color = Color.red;
                win.text = "Поражение";
            }
        }
    }

    
    IEnumerator PlayGhost() //движение призрака
    {
        for (int i = 0; i < playerGhostData.positions.Count; i++)
        {
            currentGhost.transform.position = playerGhostData.positions[i] - Raznitsa;
            currentGhost.transform.rotation = playerGhostData.rotations[i];
            yield return new WaitForSeconds(0.02f); 
            
        }
    }

    void StartRace()
    {


        if (Race)
        {

            ResetTimer();
            timerText.GetComponent<CanvasGroup>().alpha = 0;
            Race = false;
            simcadeVehicleController.CanDrive = true;
            if (circles == 1)
            {
                record = true;
            }
            else
            {
                record = false;
                StartCoroutine(PlayGhost());
            }
        }

    }
    void StartTimer() //Таймер перед стартом 
    {
        if(Race)
        {
            timer = timer - Time.deltaTime;
            
            timerText.GetComponent<CanvasGroup>().alpha = 1;
            switch ((int)timer)
            {
                case 3:
                    timerText.text = "3";
                  break;
                case 2:
                    timerText.text = "2";
                   
                    break;
                case 1:
                    timerText.text = "1";
                   
                    break;
                case 0:
                    StartRace();
                    break;

            }
        }
    }
    void ResetTimer()    
    {
        for (int i = 0; i < members.Count; i++)
        {
            members[i].time = 0;
        }
    }
   

}
