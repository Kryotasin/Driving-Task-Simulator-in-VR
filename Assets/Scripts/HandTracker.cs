using UnityEngine;
using System;
using System.IO;
using System.Text;


/// <summary>
/// This script records data each frame in a text file in the following tab-delimited format
/// Frame   Start		HeadX	HeadY	HeadZ	HandX   HandY   HandZ				
///------------------------------------------------------------------------------
/// 1       1241.806	float	float	float   float	float	float	
/// 2       4619.335	float	float	float   float	float	float	
/// </remark>
public class HandTracker : MonoBehaviour {
    public string FolderName = "D:\\IVE_Spring19\\Kshitij Sinha\\Driving-Task-Simulator-in-VR\\Data\\PositionLogs\\TestData";
    public string FileName = " - VR";
    private string OutputDir;
    
    //Things you want to write out, set them in the inspector

    public float taskNumber, startTime, uiComponentInteractionTime, uiComponentExitTime, hornTime;

    //Gives user control over when to start and stop recording, trigger this with spacebar;
    public bool startWriting;

    //Initialize some containers
    FileStream streams;
    StringBuilder stringBuilder = new StringBuilder();
    String writeString;
    Byte[] writebytes;

    void Awake()
    {
    }


    void Start()
    {
        // create a folder 
        string OutputDir = Path.Combine(FolderName, string.Concat(DateTime.Now.ToString("MM-dd-yyyy"), FileName));
        Directory.CreateDirectory(OutputDir);

        // create a file to record data
        String trialOutput = Path.Combine(OutputDir, DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + "_Results.txt");
        streams = new FileStream(trialOutput, FileMode.Create, FileAccess.Write);


        //Call the function below to write the column names
        WriteHeader();
    }


    void WriteHeader()
    {

        //output file-- order of column names here should match the order you use when writing out each value 
        stringBuilder.Length = 0;
        //add header info
        stringBuilder.Append(
        DateTime.Now.ToString() + "\t" +
        "The file contains frame by frame data of location for 3 tracked objects " + Environment.NewLine +
        "The coordinate system is in Unity world coordinates." + Environment.NewLine
        );
        stringBuilder.Append("-------------------------------------------------" +
            Environment.NewLine
            );
        //add column names
        stringBuilder.Append(
            "TaskNumber\t" + "StartTime\t" + "UIComponentInteractionTime\t" + "UIComponentExitTime\t" + "HornTime\t" + Environment.NewLine
                        );


        writeString = stringBuilder.ToString();
        writebytes = Encoding.ASCII.GetBytes(writeString);
        streams.Write(writebytes, 0, writebytes.Length);

    }

    public void WriteFile()
    {
        stringBuilder.Length = 0;
        stringBuilder.Append(
                    taskNumber + "\t"
                    + startTime + "\t"
                    + uiComponentInteractionTime + "\t"
                    + uiComponentExitTime + "\t"
                    + hornTime + "\t"

                    + Environment.NewLine
                );
        writeString = stringBuilder.ToString();
        writebytes = Encoding.ASCII.GetBytes(writeString);
        streams.Write(writebytes, 0, writebytes.Length);
    }



    public void Update()
    {
        //Use spacebar to initiate/stop recording values, you can change this if you want 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startWriting = !startWriting;
            if (startWriting)
            {
                Debug.Log("Start writing");
            }
            else
            {
                Debug.Log("Stop writing");
            }
        }

        if(Input.GetKeyDown(KeyCode.X)){
            // Close the file 
            streams.Close();
            Debug.Log("Close File");
        }
        
        if (startWriting) 
        {
            WriteFile();
        }


    }

     public void OnApplicationQuit()
    {
        streams.Close();

    }

}


