using LiteNetLib;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Server : MonoBehaviour, INetEventListener
{
    private NetManager server;
    public const short PORT = 9050;
    public const string KEY = "MYKEY";

    private void Awake()
    {
        Debug.Log("Awake");
        server = new NetManager(this);
        server.Start(PORT);
    }

    private void Update()
    {
        server.PollEvents();
    }

    public void OnConnectionRequest(ConnectionRequest request)
    {
        Debug.Log("Server::OnConnectionRequest");
        request.AcceptIfKey(KEY);
    }
    public void OnNetworkError(IPEndPoint endPoint, SocketError socketError) => Debug.Log("Server::OnNetworkError");
    public void OnNetworkLatencyUpdate(NetPeer peer, int latency) => Debug.Log("Server::OnNetworkLatencyUpdate");
    public void OnNetworkReceive(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod) => Debug.Log("Server::OnNetworkReceive");
    public void OnNetworkReceiveUnconnected(IPEndPoint remoteEndPoint, NetPacketReader reader, UnconnectedMessageType messageType) => Debug.Log("Server::OnNetworkReceiveUnconnected");
    public void OnPeerConnected(NetPeer peer) => Debug.Log("Server::OnPeerConnected");
    public void OnPeerDisconnected(NetPeer peer, DisconnectInfo disconnectInfo) => Debug.Log("Server::OnPeerDisconnected");
}