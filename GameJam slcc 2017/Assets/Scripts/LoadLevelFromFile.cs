using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

[ExecuteInEditMode]
public class LoadLevelFromFile : MonoBehaviour {
	public TextAsset textAsset;

	public Transform W;
	public Transform P;
	public Transform S;
	public Transform E;
	public Transform G;
	public Transform D;
	public Transform BK;
	public Transform BL;
	public Transform RK;
	public Transform RL;
	public Transform YK;
	public Transform YL;
	public Transform GK;
	public Transform GL;

	void OnEnable()
	{
		Create ();
	}
	// Use this for initialization
	void Create () {
        GameObject blueDoors = new GameObject("blueDoors");
        GameObject redDoors = new GameObject("redDoors");
        GameObject greenDoors = new GameObject("greenDoors");
        GameObject yellowDoors = new GameObject("yellowDoors");
        GameObject parent = null;
        var text = textAsset.text;
		string[] lines = text.Split (new string[]{ System.Environment.NewLine }, System.StringSplitOptions.None);

		for (int line = 1; line < lines.Length; line++) {
			string[] items = lines[line].Split (new char[]{ ',' }, System.StringSplitOptions.None);
            for (int i = 0; i < items.Length; i++) {
                Transform myTransform = null;
                if (items[i] == "W")
                    myTransform = W;
                else if (items[i] == "P")
                    myTransform = P;
                else if (items[i] == "S")
                    myTransform = S;
                else if (items[i] == "E")
                    myTransform = E;
                else if (items[i] == "D")
                    myTransform = D;
                else if (items[i] == "G")
                    myTransform = G;
                else if (items[i] == "SG")
                    myTransform = G;
                else if (items[i] == "BK")
                    myTransform = BK;
                else if (items[i] == "BL")
                {
                    myTransform = BL;
                    parent = blueDoors;
                }
                else if (items[i] == "RK")
                    myTransform = RK;
                else if (items[i] == "RL")
                {
                    myTransform = RL;
                    parent = redDoors;
                }
                else if (items[i] == "YK")
                    myTransform = YK;
                else if (items[i] == "YL")
                {
                    myTransform = YL;
                    parent = yellowDoors;
                }
                else if (items[i] == "GK")
                    myTransform = GK;
                else if (items[i] == "GL")
                {
                    myTransform = GL;
                    parent = greenDoors;
                }
                if (myTransform != null)
                {
                    Transform trans = Instantiate(myTransform, new Vector3(i, 0, -line), Quaternion.identity);
                    if(parent != null) trans.parent = parent.transform;
                    parent = null;
                }

			}
		}
	}
}
