using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCourseSetup : MonoBehaviour
{
    public int errors;
    public float timer = 0;

    public bool startLine = true;
    public bool finishLine = false;

    int iterate = 0;

    public ControllerGrabObject CGO;
    private void FixedUpdate()
    {
        if(finishLine)
        {
            if(iterate==0)
            {
                FileWriter w = new FileWriter("filename.txt");
                w.write("ObstacleCourse");
                w.write("Locomotion: " + CGO.locomotionSetting);
                w.write("Errors: " + errors);
                w.write("Time: " + timer);
                iterate = 1;
            }
        }
        else if(!startLine && !finishLine)
        {
            timer += Time.deltaTime;
        }
    }
}
