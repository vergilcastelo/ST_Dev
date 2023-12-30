# SpecularTheory
Specular Theory Dev Challenge

by Vergil Castelo

Software:
 - Unity 3D v2021.3.33f1 LTS
 - VS Code v1.85
     -VS Code Unity Extention v0.9.3

Setup:
 - root folder named 'SPECULARTHEORY'
 - Unity Project 3D VR Template v5.0.1

 1. Global Data & Editor Tools:
 - Open ST_Dev project in Unity
 - Open 1_GlobalData scene 
 - press Play to run and generate 20 instances
 - in editor select Window from top menu
 - select Player Utility Tool to display tool
    - search GO names by input in field
    - or select search by color option
    - select an option to display GO by color
    - select results to activate in hierarchy

    Notes: 
    - I modified the implementation for filtering by color. Initially, having tried the same search box
    for both filters lead to issues in my code, specifically string to Color type, name conversion. I thought 
    it may be more user-friendly to separate the two requirements. And add a "show available colors" selections 
    and have the user filter when a color is chosen.
       

 3. Advanced Interaction:
 - Open ST_Dev project in Unity
 - Open 3_AdvancedInteraction scene
 - Build and Run

    Notes: 
    - I added text output under each knob for convienience and debugging. It helped in testing the event 
    triggers and displays value of knob position in degrees, valueID, and a mapped value.  The mapped value 
    maps the knob angle to the knob's given range for a specific value.


 4. Origin Shifting:
 - Open ST_Dev project in Unity
 - Open 4_AdvancedInteraction scene
 - Press "Play"
 - Game window will emulate an HMD
 - Overlay Menu with mapping of desktop controls to HMD controls should be visible 

    Notes:
    - I used the Virtual Reality Toolkit Scene template for this challenge as it was a good starting point with much of
    the VR framework set. I don't have an HMD unit, so I used the Mock HMD XR Player setting in the XR Plugin Management package
    for test in the editor. That setting and some other items would need to be configured to run on an actual device. Hopefully, 
    the Mock HMD Player is sufficent for demonstrating my understanding of the VR space and meeting challenge requirements.  



General Notes:
 - dev_vergil branch is my working branch, pr to main after 4-5+ smaller commits 
 - 2 of the 5 challenges done at the time of initial submission 12/28.  I wasn't sure how long I had to complete and 
 submit, so I decided to submit 2 for the time being and I am continuing work on 1 more. Target day for completion is 
 Tuesday 01/02 since Monday is a New Years Day. 