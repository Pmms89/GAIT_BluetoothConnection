using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.IO.Ports;

public class BluetoothConnection : MonoBehaviour
{
    SerialPort sp = new SerialPort("\\\\.\\COM4", 9600, Parity.None, 8, StopBits.One);

   public string msg;

    bool localLocker = true;



    void Start()
    {
        //  sp.ReadTimeout = 2000;
        // sp.Open();
        // Timeout after 2 seconds.
        sp.ReadTimeout = 50;
        sp.Open();

    }

    void Update()
    {

        string input;

        try
        {
            // input = sp.ReadByte();
              sp.WriteLine("b");
              sp.WriteLine("y");
              sp.WriteLine("r");

            // Debug.Log(sp.ReadLine());
            //Debug.Log(Console.ReadLine());

            SerialEvent(sp);

        }

        catch (TimeoutException e)
        {
         //   Debug.Log(e);
        }

    }
    
    void SerialEvent(SerialPort myPort)
    {
     
        string myString = myPort.ReadLine(); //the ascii value of the "|" character

        if (myString != null)
        {
            Debug.Log(myString);
        }

    }

    void OnApplicationQuit()
    {
        sp.Close();
    }

}
