using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GateType { multiplyType, additionType}
public class GateController : MonoBehaviour
{
    public int gateValue;
    public TMPro.TextMeshProUGUI gateText;
    public GateType gateType;
    private GameObject playerSpawnerGO;
    private PlayerSpawnerController playerSpawner; //Script
    bool hasGateUsed;
    private GateHolderController gateHolder; //Script

    void Start()
    {
        playerSpawnerGO = GameObject.FindGameObjectWithTag("PlayerSpawner");
        playerSpawner = playerSpawnerGO.GetComponent<PlayerSpawnerController>();
        gateHolder = transform.parent.gameObject.GetComponent<GateHolderController>();

        AddGateValueAndSymbol();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && hasGateUsed == false)
        {
            hasGateUsed = true;
            //Karakteri cogalt
            playerSpawner.SpawnPlayer(gateValue, gateType);
            gateHolder.CloseGates();
            Destroy(gameObject);
        }
    }

    private void AddGateValueAndSymbol()
    {
        switch (gateType)
        {
            case GateType.multiplyType:
                gateText.text = "X" + gateValue.ToString();
                break;

            case GateType.additionType:
                gateText.text = "+" + gateValue.ToString();
                break;
            default:
                break;
        }
    }
}
