using Unity.Netcode;
using UnityEngine;

public class PlayersManager : NetworkSingleton<PlayersManager>
{
    NetworkVariable<int> playersCount = new NetworkVariable<int>();

    public int PlayerCount
    {
        get { return playersCount.Value; }
    }

    private void Start()
    {
        if (IsServer)
        {

            NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
            {
                playersCount.Value++;
                Logger.Instance.LogInfo($"Player {id} is connected.");
            };
            NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
            {
                playersCount.Value--;
                Logger.Instance.LogInfo($"Player {id} is disconnected.");
            };
        }

    }
}
