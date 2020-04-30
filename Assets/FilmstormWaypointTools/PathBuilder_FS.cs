using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[AddComponentMenu("Filmstorm/WayPointManager")]
public class PathBuilder_FS : MonoBehaviour {
	[Header("Customise Look of Paths")]
	public Color gizmoColor = Color.black;

	
	[Header("Path Points Holder")]
	[Tooltip("This is the list that holds all the Path Points")]
	public List<GameObject> pathPoints = new List<GameObject>(); 
	
	GameObject pathFinder;
	
	GameObject pathPoint;



	
	public void BuildPath() {
		
		pathFinder = this.gameObject;
		pathPoint = new GameObject ("pathPointUserCreated");
		pathPoint.transform.parent = pathFinder.transform;
		pathPoint.AddComponent<DrawFilmstormGUI> ();
		pathPoints.Add (pathPoint);

	}

	
	public void ClearPath() {

		foreach (GameObject go in pathPoints) {
			DestroyImmediate (go);
		}

		pathPoints.Clear ();
	}





	
	public List<GameObject> CreatedPaths 
	{
		get { return pathPoints; }
	}





	
	void OnDrawGizmos () {

		for (var i = 1; i < pathPoints.Count; i++) {
			Gizmos.color = gizmoColor;
			Gizmos.DrawLine (pathPoints [i - 1].transform.position, pathPoints [i].transform.position);

		}
}



}
