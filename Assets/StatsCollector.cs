using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class StatsCollector : MonoBehaviour {
    [SerializeField] private float pollingPeriod = 10f;
    [SerializeField] private float savePeriod = 30f;

    public static bool isCollecting = false;

    // Data buffers
    private List<float> timeBuf = new List<float>();
    private List<int> countBuf = new List<int>();
    private Dictionary<CreatureStats.StatType, List<List<float>>> dataBufs = new Dictionary<CreatureStats.StatType, List<List<float>>>();

    // Paths
    private string basePath;
    private string timePath = "time";
    private string countPath = "counts";
    private Dictionary<CreatureStats.StatType, string> paths = new Dictionary<CreatureStats.StatType, string>();

    private Mutex dataMut = new Mutex(); // Mutex for data access

    private void Awake() {
        GetPaths();
        InitBufs();
    }

    private void Start() {
        ClearFiles();
        StartCoroutine(DataSaveLoop());
    }

    public void StartCollection() {
        isCollecting = true;
        StartCoroutine(DataCollectLoop());
    }

    public void StopCollection() {
        isCollecting = false;
        SaveFiles();
    }

    IEnumerator DataCollectLoop() {
        Debug.Log("Data collection started.");
        while (isCollecting) {
            CollectDataPoint();

            yield return new WaitForSeconds(pollingPeriod);
        }
    }

    IEnumerator DataSaveLoop() {
        while(true) {
            SaveFiles();

            yield return new WaitForSecondsRealtime(savePeriod);
        }
    }

    /// <summary>
    /// Gets paths for data files
    /// </summary>
    private void GetPaths() {
        basePath = System.IO.Path.GetDirectoryName(Application.dataPath) + "/data/";
        Debug.Log("Data will be logged to path: " + basePath);

        foreach (CreatureStats.StatType stat in System.Enum.GetValues(typeof(CreatureStats.StatType))) {
            paths[stat] = basePath + stat.ToString() + ".csv";
        }
    }

    /// <summary>
    /// Initialises data buffers
    /// </summary>
    private void InitBufs() {
        foreach (CreatureStats.StatType stat in System.Enum.GetValues(typeof(CreatureStats.StatType))) {
            dataBufs[stat] = new List<List<float>>();
        }
    }

    /// <summary>
    /// Clears data buffers
    /// </summary>
    private void ClearBufs() {
        timeBuf.Clear();
        countBuf.Clear();

        foreach (CreatureStats.StatType stat in System.Enum.GetValues(typeof(CreatureStats.StatType))) {
            dataBufs[stat].Clear();
        }
    }

    /// <summary>
    /// Collects data point
    /// </summary>
    private void CollectDataPoint() {
        // PROTECTED REGION
        dataMut.WaitOne();
        Debug.Log("Collection data point - in protected region");

        // Colect time and count data
        timeBuf.Add(Time.time);
        countBuf.Add(StatsManager.Instance.CreatureValues.Count);

        // Collect stat data
        foreach(CreatureStats.StatType stat in System.Enum.GetValues(typeof(CreatureStats.StatType))) {
            dataBufs[stat].Add(GetStatsOfType(stat));
        }

        Debug.Log("Data point collected - exiting protected region");
        dataMut.ReleaseMutex();
        // END PROTECTED REGION
    }

    public void SaveFiles() {
        // Save data if we have data to save
        if (timeBuf.Count > 0) {
            // Enter protected region
            dataMut.WaitOne();
            Debug.Log("Saving data - entering protected region");

            // Write time and count data
            using (StreamWriter timeW = new StreamWriter(basePath + timePath + ".csv", append: true)) {
                foreach (float entry in timeBuf) {
                    timeW.WriteLine(entry.ToString());
                }
            }

            using (StreamWriter countW = new StreamWriter(basePath + countPath + ".csv", append: true)) {
                foreach (int entry in countBuf) {
                    countW.WriteLine(entry.ToString());
                }
            }

            // Write stats data
            foreach (CreatureStats.StatType stat in System.Enum.GetValues(typeof(CreatureStats.StatType))) {
                using (StreamWriter writer = new StreamWriter(paths[stat], append: true)) {
                    foreach (List<float> row in dataBufs[stat]) {
                        WriteListToFile(row, writer);
                    }
                }
            }

            ClearBufs();

            Debug.Log("Saving complete - Exiting protected region");
            dataMut.ReleaseMutex();
        }
    }

    /// <summary>
    /// Gets stats of all creatures
    /// </summary>
    /// <param name="statType">type of stat to get</param>
    /// <returns>List of stat values of all creatures</returns>
    private List<float> GetStatsOfType(CreatureStats.StatType statType) {
        List<float> output = new List<float>();

        foreach (Dictionary<CreatureStats.StatType, float> creatureValues in StatsManager.Instance.CreatureValues) {
            output.Add(creatureValues[statType]);
        }

        return output;
    }

    /// <summary>
    /// Writes a list of data to specified file
    /// </summary>
    /// <param name="list">List of data to be written</param>
    /// <param name="writer">Streamwriter object to be written to</param>
    private void WriteListToFile(List<float> list, StreamWriter writer) {
        writer.WriteLine(string.Join(",", list));
    }

    private void ClearFiles() {
        // Write time and count data
        using (StreamWriter timeW = new StreamWriter(basePath + timePath + ".csv", append: false)) {
            foreach (float entry in timeBuf) {
                timeW.WriteLine("");
            }
        }

        using (StreamWriter countW = new StreamWriter(basePath + countPath + ".csv", append: false)) {
            foreach (int entry in countBuf) {
                countW.WriteLine("");
            }
        }

        // Write stats data
        foreach (CreatureStats.StatType stat in System.Enum.GetValues(typeof(CreatureStats.StatType))) {
            using (StreamWriter writer = new StreamWriter(paths[stat], append: false)) {
                writer.WriteLine("");
            }
        }
    }
}