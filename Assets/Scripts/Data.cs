using UnityEngine.Networking;
public class Data : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        base.OnServerAddPlayer(conn, playerControllerId);
    }
    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkServer.RegisterHandler(100, ReceiveInt);

    }
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        MyMessage myMessage = new MyMessage();
        myMessage.number = 2;
        conn.Send(100, myMessage);
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);

    }

    public void ReceiveInt(NetworkMessage networkMessage)
    { 
    
    }
}
public class MyMessage : MessageBase
{
    public int number;    
    public override void Serialize(NetworkWriter writer)
    {
        writer.Write(number);
    }
    public override void Deserialize(NetworkReader reader)
    {
        number = reader.ReadInt32();
    }
}