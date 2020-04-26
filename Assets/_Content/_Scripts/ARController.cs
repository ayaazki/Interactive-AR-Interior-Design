using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

#if UNITY_EDITOR
using input = GoogleARCore.InstantPreviewInput;
#endif
public class ARController : MonoBehaviour
{
    private List<TrackedPlane> newTrackPlanes = new List<TrackedPlane>();

    public GameObject gridPrefab;
    public GameObject room;
    public GameObject ARCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        Session.GetTrackables<TrackedPlane>(newTrackPlanes, TrackableQueryFilter.New);

        for (int i = 0; i < newTrackPlanes.Count; i++)
        {
            GameObject grid = Instantiate(gridPrefab, Vector3.zero, Quaternion.identity, transform);

            grid.GetComponent<GridVisualiser>().Initialize(newTrackPlanes[i]);
        }

        //Check if the user touched the screen (incase there is no interaction no need to continue update)
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        //Check if the user touched any of tracked planes
        TrackableHit hit;
        if (Frame.Raycast(touch.position.x, touch.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit))
        {
            //enable object
            room.SetActive(true);

            //Create a new Anchor

            Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

            //Set the postion of the room to be the same as hit position
            room.transform.position = hit.Pose.position;
            room.transform.rotation = hit.Pose.rotation;

            //Make the Door face the camera
            Vector3 cameraPosition = ARCamera.transform.position;

            //Rotate it around Y axis
            cameraPosition.y = hit.Pose.position.y;

            //Rotate the Door to face the camera
            room.transform.LookAt(cameraPosition, room.transform.up);

            //ARCore will keep understanding the world and update the anchors accordingly hence we need to attach our room to anchor
            room.transform.parent = anchor.transform;

        }
    }
}
