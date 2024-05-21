using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button startServerBtn;

    [SerializeField]
    private Button startHostBtn;

    [SerializeField]
    private Button startClientBtn;

    private void Start()
    {
        startServerBtn.onClick.AddListener(() =>
        {
            if(NetworkManager.Singleton.StartServer())
            {
                Logger.Instance.LogInfo("Successfully started the Server");
            }
            else
            {
                Logger.Instance.LogError("Error while starting the Server");
            }
        });

        startClientBtn.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartClient())
            {
                Logger.Instance.LogInfo("Successfully started the Client");
            }
            else
            {
                Logger.Instance.LogError("Error while starting the Client");
            }
        });


        startHostBtn.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartHost())
            {
                Logger.Instance.LogInfo("Successfully started the Host");
            }
            else
            {
                Logger.Instance.LogError("Error while starting the Host");
            }
        });
    }
}
