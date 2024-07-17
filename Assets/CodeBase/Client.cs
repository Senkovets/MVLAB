using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public string Email;
    public string Password;
    public List<ProductionLine> ProductionLines;

    private static Client instance;

    public static Client Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Client>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("ClientSingleton");
                    instance = singletonObject.AddComponent<Client>();
                }
            }
            return instance;
        }
    }


}
