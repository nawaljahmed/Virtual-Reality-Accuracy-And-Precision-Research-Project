# HTC Vive Research Project

The final report for this project can be found [here](https://github.com/NawalJAhmed/HTC-Vive-Research-Project/blob/master/Reports/4th%20Report%20-%20Accuracy%20and%20Precision%20in%20Virtual%20Reality.pdf) along with the other reports. A video of the demo can be found at the bottom of this page.

This was a research project done for my User Interface Engineering Class. My group and I decided on determining if it was possible to train someone in a virtual enviornment such as throwing a ball to a target and extrapolate the results of that into a real life space.

The testing method was done by all group members in which we all took turns throwing a ball onto a target at different disatances a select number of time and recorded those results on a map to determine accuracy and precision. We made a scoring system to register how well each participant did.

We then built the VR space in Unity using C#. The environment was made to simulate the area in which the baseballs were thrown in real life. Due to the enclosed environment in which the real life testing was done, physics factors such as wind speed were acceptable to be ignored. We wanted to test at a base level to determine if there was a correlation between training in a normal room in reality versus virtual reality. If there was a correlation, then factors such as wind speed would be added on and tested to see if there still was a correlation. Other natural factors had to be added on by default such as the speed of the ball being pitched, gravity, drag and the Magnus force related to the spin of the ball. Some of these were made using built in libraries as simulating them from scratch could have yeilded in less time to make a proper environment and therefore less complete results. The target in the virtual environment was made using images of the target we used actually used. We measured the target and used the same increments inside the VR space. We made a script to record the result of the location the ball hit on the target. If the ball missed, then a missed value would be recorded.

After the virtual enviornment was made, all the participants were given time to practice in the space with similar coordinates. Once the training had concluded, the participants did the same tests as we completed in real time and used the script to record the results. The participants again returned to the same physical tests to note if there was any difference achieved.

Ultimately, there were slight improvments in accuracy. The largest improvment was made at the longest distance, showing double the score that was originally obtained.

## Video Demo

<p align="center">
  <a href="https://www.youtube.com/watch?v=lTSCO8_pkT0
  " target="_blank"><img src="https://user-images.githubusercontent.com/11577850/72565235-6bdeff80-387f-11ea-872c-05d02eaaef64.PNG" width="500" height="281.25"
  alt="YouTube video demo"/></a>
  <br>
  <em>YouTube Video Demo (Click on Image for Video) </em>
</p>
