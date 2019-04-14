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
public class BasicObjectTracker : MonoBehaviour {
    public string FolderName = "D:\\IVE_Spring19\\Kshitij Sinha\\Driving-Task-Simulator-in-VR\\Data\\PositionLogs\\TestData";
    public string FileName = " - VR";
    private string OutputDir;
    
    //Things you want to write out, set them in the inspector
    public GameObject VRCamera;
    public GameObject RightHandController;

    public GameObject targetSpawnController;

    public GameObject gazeMarker;

    private TargetSpawner targetSpawnerScript;

    //Gives user control over when to start and stop recording, trigger this with spacebar;
    public bool startWriting;

    //Initialize some containers
    FileStream streams;
    StringBuilder stringBuilder = new StringBuilder();
    String writeString;
    Byte[] writebytes;

    void Awake()
    {
        targetSpawnerScript = targetSpawnController.GetComponent<TargetSpawner>();
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
            "FrameNumber\t" + "Timestamp\t" + "Target Number\t" + "TargetX\t" + "TargetY\t" + "TargetZ\t" + "HeadX\t" + "HeadY\t" + "HeadZ\t" + "HandX\t" + "HandY\t" + "HandZ\t" + "GazeX\t" + "GazeY\t" + "GazeZ\t" + Environment.NewLine
                        );


        writeString = stringBuilder.ToString();
        writebytes = Encoding.ASCII.GetBytes(writeString);
        streams.Write(writebytes, 0, writebytes.Length);

    }

    void WriteFile()
    {
        stringBuilder.Length = 0;
        stringBuilder.Append(
                    Time.frameCount + "\t"
                    + Time.time * 1000 + "\t"

                    + targetSpawnerScript.targetNumber + "\t"
                    + targetSpawnerScript.spawnPosition.x.ToString() + "\t"
                    + targetSpawnerScript.spawnPosition.y.ToString() + "\t"
                    + targetSpawnerScript.spawnPosition.z.ToString() + "\t"

                    + VRCamera.transform.position.x.ToString() + "\t"
                    + VRCamera.transform.position.y.ToString() + "\t"
                    + VRCamera.transform.position.z.ToString() + "\t"
                    
                    + RightHandController.transform.position.x.ToString() + "\t"
                    + RightHandController.transform.position.y.ToString() + "\t"
                    + RightHandController.transform.position.z.ToString() + "\t" 

                    + gazeMarker.transform.position.x.ToString() + "\t"
                    + gazeMarker.transform.position.y.ToString() + "\t"
                    + gazeMarker.transform.position.z.ToString() + "\t"
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


