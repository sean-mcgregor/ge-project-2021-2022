using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public bool onWater; //Determine if player on water
    private GameObject currentModel;
    public GameObject FirstPlayerModelPrefab; //Drag the initial player prefab in here
    public GameObject SecondPlayerModelPrefab; //Drag the second player prefab in here
    public GameObject Player;

    private bool onWaterLastFrame = false;

    private void Start() {
        
        currentModel = Player.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y > 3.6)
        {
           
            onWater = false;
        } else {

            onWater = true;
        }

        if (onWater && !onWaterLastFrame)
        {
            Vector3 rotation = new Vector3(0, Player.transform.localRotation.eulerAngles.y, 0);
            Destroy(currentModel);
            currentModel = Instantiate(SecondPlayerModelPrefab, Player.transform.position, Quaternion.Euler(rotation));
            currentModel.transform.SetParent(Player.transform);
        }
        else if (!onWater && onWaterLastFrame)
        {
            Vector3 rotation = new Vector3(0, Player.transform.localRotation.eulerAngles.y, 0);
            Destroy(currentModel);
            currentModel = Instantiate(FirstPlayerModelPrefab, Player.transform.position, Quaternion.Euler(rotation));
            currentModel.transform.SetParent(Player.transform);

        }
        
        onWaterLastFrame = onWater;
    }
}