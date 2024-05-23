using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private Button startServerBtn;

    [SerializeField]
    private Button startHostBtn;

    [SerializeField]
    private Button startClientBtn;

    [SerializeField]
    private TextMeshProUGUI playersInGameText;

    [SerializeField]
    private TMP_InputField joinCodeInput;

    private void Awake()
    {
        Cursor.visible = true;
    }
    private void Update()
    {

        playersInGameText.text = $"Players in game: {PlayersManager.Instance.PlayerCount.ToString()}";
    }

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

        startClientBtn.onClick.AddListener(async () =>
        {
            if (RelayManager.Instance.IsRelayEnabled && !string.IsNullOrEmpty(joinCodeInput.text))
                await RelayManager.Instance.JoinRelay(joinCodeInput.text);


            if (NetworkManager.Singleton.StartClient())
            {
                Logger.Instance.LogInfo("Successfully started the Client");
            }
            else
            {
                Logger.Instance.LogError("Error while starting the Client");
            }
        });


        startHostBtn.onClick.AddListener(async () =>
        {
            // this allows the UnityMultiplayer and UnityMultiplayerRelay scene to work with and without
            // relay features - if the Unity transport is found and is relay protocol then we redirect all the 
            // traffic through the relay, else it just uses a LAN type (UNET) communication.
            if (RelayManager.Instance.IsRelayEnabled)
                await RelayManager.Instance.SetupRelay();

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
