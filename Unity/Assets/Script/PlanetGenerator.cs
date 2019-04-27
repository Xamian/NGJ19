using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour {

	[SerializeField]
	GameObject hexagonTile;
	[SerializeField]
	GameObject pentagonTile;
	[SerializeField]
	Vector3 originPoint = Vector3.zero;
	public float tileLength = 1.0f;
	public int numOfTilePerEdge = 3;

	// Use this for initialization
	void Start () {
		Generate ();
	}

	public void Generate () {
		List<int[]> edgeConnections = new List<int[]> ();
		edgeConnections.Add (new int[] { 1, 5, 7, 10, 11 }); //0
		edgeConnections.Add (new int[] { 5, 7, 8, 9 }); //1
		edgeConnections.Add (new int[] { 3, 4, 6, 10, 11 }); //2
		edgeConnections.Add (new int[] { 4, 6, 8, 9 }); //3
		edgeConnections.Add (new int[] { 5, 9, 11 }); //4
		edgeConnections.Add (new int[] { 9, 11 }); //5
		edgeConnections.Add (new int[] { 7, 8, 10 }); //6
		edgeConnections.Add (new int[] { 8, 10 }); //7
		edgeConnections.Add (new int[] { 9 }); //8
		edgeConnections.Add (new int[] { }); //9
		edgeConnections.Add (new int[] { 11 }); //10

		float edgeLength = tileLength * (numOfTilePerEdge + 1);
		float radius = 0.9519565163f * edgeLength; //https://en.wikipedia.org/wiki/Regular_icosahedron#Dimensions

		//Generate 12 pentagons
		float t = (1f + Mathf.Sqrt (5f)) / 2f;
		Vector3[] pentagonPoints = new Vector3[12];
		pentagonPoints[0] = (new Vector3 (-1f, t, 0f).normalized * radius);
		pentagonPoints[1] = (new Vector3 (1f, t, 0f).normalized * radius);
		pentagonPoints[2] = (new Vector3 (-1f, -t, 0f).normalized * radius);
		pentagonPoints[3] = (new Vector3 (1f, -t, 0f).normalized * radius);

		pentagonPoints[4] = (new Vector3 (0f, -1f, t).normalized * radius);
		pentagonPoints[5] = (new Vector3 (0f, 1f, t).normalized * radius);
		pentagonPoints[6] = (new Vector3 (0f, -1f, -t).normalized * radius);
		pentagonPoints[7] = (new Vector3 (0f, 1f, -t).normalized * radius);

		pentagonPoints[8] = (new Vector3 (t, 0f, -1f).normalized * radius);
		pentagonPoints[9] = (new Vector3 (t, 0f, 1f).normalized * radius);
		pentagonPoints[10] = (new Vector3 (-t, 0f, -1f).normalized * radius);
		pentagonPoints[11] = (new Vector3 (-t, 0f, 1f).normalized * radius);

		int counter = 0;
		foreach (Vector3 point in pentagonPoints) {
			Transform pentagon = (Instantiate (pentagonTile, point + originPoint, Quaternion.identity) as GameObject).transform;
			pentagon.up = point - originPoint;
			pentagon.name = "pentagon " + counter;
			counter++;
			//Set local y rotation
		}

		//Fill in with hexagons
		//Fill in lines between pentagons
		for (int p = 0; p < pentagonPoints.Length; p++) {
			Debug.Log ("Finding connections from pentagon number " + p);
			for (int p2 = 0; p2 < edgeConnections[p].Length; p2++) {
				Debug.Log ("Connecting from " + p + " to " + edgeConnections[p][p2]);
				for (int i = 0; i < numOfTilePerEdge; i++) {
					float lerpValue = (i + 1f) / (numOfTilePerEdge + 1f);
					Vector3 hexagonPoint = Vector3.Lerp (pentagonPoints[p], pentagonPoints[edgeConnections[p][p2]], lerpValue);
					Debug.Log (lerpValue);
					//Debug.Log (hexagonPoint);
					Transform hexagon = (Instantiate (hexagonTile, hexagonPoint, Quaternion.identity) as GameObject).transform;
					hexagon.up = hexagonPoint - originPoint;
				}
			}
		}
		//Fill in empty triangles

	}
}