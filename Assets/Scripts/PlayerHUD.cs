using TMPro;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHUD : NetworkBehaviour
{
    NetworkVariable<NetworkString> playerName = new NetworkVariable<NetworkString>();
    private bool overlaySet;
    public TextMeshProUGUI localPlayerOverlayText;

    public override void OnNetworkSpawn()
    {
        if(IsServer)
        {
            playerName.Value = $"Player {OwnerClientId}";
        }
    }


    public void SetOverlay() 
    {
        localPlayerOverlayText.text=playerName.Value;
    }

    private void Update()
    {
        if(!overlaySet && string.IsNullOrEmpty(playerName.Value))
        {
            SetOverlay();
            overlaySet = true;
        }
    }

}
