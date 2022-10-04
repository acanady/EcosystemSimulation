using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGrabber : MonoBehaviour
{
    private float currTime;
    private int timeCSV;
    private string filename = "";
    public EcosystemManager Ecomanager;

    private TextWriter ppTextWriter;
    private TextWriter apreysrTextWriter;

    

    private void Start()
    {
        if (Ecomanager == null) Ecomanager = GameObject.FindGameObjectWithTag("EcoManager").GetComponent<EcosystemManager>();
        InitializeTextWriters();
       
    }

    //Every second of in game simulation time the CSV files are updated
    private void Update()
    {
        currTime += Time.fixedDeltaTime;
        if(currTime >= 1)
        {
            currTime = 0;
            timeCSV++;
            WriteToCSVs();
        }
    }


    public void WriteToCSVs()
    {
        PreyPopOverTime();
        AvgPreySensoryRadiusOverTime();
    }

    public void PreyPopOverTime()
    {
        ppTextWriter.WriteLine(timeCSV + "," + Ecomanager.prey.Count);
    }

    public void AvgPreySensoryRadiusOverTime()
    {
        float totalSensoryRadius = 0;
        float avgSensoryRadius = 0;

        foreach(var entity in Ecomanager.prey)
        {
            totalSensoryRadius += Ecomanager.SensoryRadiusOfEntities[entity].sensoryRadius;
        }

        if (Ecomanager.prey.Count > 0)
        {
            avgSensoryRadius = totalSensoryRadius / Ecomanager.prey.Count;
            apreysrTextWriter.WriteLine(timeCSV + "," + avgSensoryRadius);
            Debug.Log("average sensory radius: " + avgSensoryRadius);
        }
    }

    public void InitializeTextWriters()
    {
        filename = Application.dataPath + "/preypopovertime.csv";
        ppTextWriter = new StreamWriter(filename, false);
        filename = Application.dataPath + "/avgsensoryradiusovertime.csv";
        apreysrTextWriter = new StreamWriter(filename, false);
    }

    public void CloseTextWriters()
    {
        ppTextWriter.Close();
        apreysrTextWriter.Close();
    }

    private void OnApplicationQuit()
    {
        CloseTextWriters();
    }
}
