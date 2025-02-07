

using System.Threading;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int PickedAmount;
    public bool wiresfixed;
    public GameObject door;
    private bool isCompleted;
    private void Start()
    {
       PickedAmount=0;
       wiresfixed=false;
       isCompleted=false;
    }

    public void PickUpPicked(){
        PickedAmount++;
        Debug.Log("PickedAmount: "+PickedAmount);
    }
    void Update(){
        if(wiresfixed&&PickedAmount>=4&&!isCompleted){
            door.SetActive(false);
            Debug.Log("Door?");
            isCompleted=true;
        }
    }
}