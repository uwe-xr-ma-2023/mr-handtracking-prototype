using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PDollarGestureRecognizer;


public class PointPoseAction : MonoBehaviour
{
    public TrailRenderer trailRenderer;
    public TMP_Text debugText;
    private AudioSource audioSource;
    private List<Gesture> trainingSet = new List<Gesture>();
    private float debouncePoseEndDuration = 0.1f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        trailRenderer.enabled = false;

        TextAsset[] gesturesXml = Resources.LoadAll<TextAsset>("GestureSet/10-stylus-MEDIUM/");
        foreach (TextAsset gestureXml in gesturesXml)
            trainingSet.Add(GestureIO.ReadGestureFromXML(gestureXml.text));
    }
    public void OnPoseStart()
    {
        StopCoroutine(OnPoseEnding());
        audioSource.Play();
        trailRenderer.enabled = true;
    }

    public void OnPoseEnd()
    {
        Debug.Log("OnPoseEnd");
        StartCoroutine(OnPoseEnding());
       
    }
    // Debounce the pose detector end event as it gets triggered
    // too easily
    IEnumerator<WaitForSeconds> OnPoseEnding()
    {
        yield return new WaitForSeconds(debouncePoseEndDuration);
        OnPoseEnding();
        audioSource.Play();
        trailRenderer.enabled = false;
        string gesture = RecogniseGesture();
        trailRenderer.Clear();
    }

    List<Point> BuildPointsArray()
    {
        List<Point> points = new List<Point>();
        // Get positions from ink trail renderer
        Vector3[] trailRecorded = new Vector3[trailRenderer.positionCount];
        int positions = trailRenderer.GetPositions(trailRecorded);
        // Add PPDollar Point objects for each position on ink to points array
        foreach (Vector3 trail in trailRecorded)
        {
            points.Add(new Point(trail.x, -trail.y, 0));
        }
        return points;
    }

    string RecogniseGesture()
    {
        List<Point> points = BuildPointsArray();
        // User hasn't drawn enough points with inkTrail
        if (points.Count < 10)
        {
            return "";
        }
        // Create PDollar gesture and classify against existing gestures
        Gesture candidate = new Gesture(points.ToArray());
        Result gestureResult = PointCloudRecognizer.Classify(candidate, trainingSet.ToArray());

        string resultString = gestureResult.GestureClass + " " + gestureResult.Score;
        if (debugText)
        {
            debugText.text = resultString;
        }
        return gestureResult.Score > 0.8 ? gestureResult.GestureClass : "";
    }
}
