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
		float edgeLength = tileLength * (numOfTilePerEdge + 1);
		float goldenRatio = 0.0f;
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

		foreach (Vector3 point in pentagonPoints) {
			Transform pentagon = (Instantiate (pentagonTile, point, Quaternion.identity) as GameObject).transform;
			pentagon.up = point - originPoint;
			//Set local y rotation
		}

		//Fill in with hexagons
		for (int i = 0; i < numOfTilePerEdge; i++) {
			float lerpValue = (i + 0.5f) / numOfTilePerEdge + 1;
			Vector3 hexagonPoint = Vector3.Lerp (pentagonPoints[0], pentagonPoints[1], t);
			Debug.Log (lerpValue);
			Debug.Log (hexagonPoint);
			Transform hexagon = (Instantiate (hexagonTile, hexagonPoint, Quaternion.identity) as GameObject).transform;
			hexagon.up = hexagonPoint - originPoint;
		}
	}

}