using UnityEngine;
using System.Collections;

public class Matches : MonoBehaviour
{

		private MatchObject _matchSingleton;

		// Use this for initialization
		void Start ()
		{
				_matchSingleton = MatchObject.MatchSingleton;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (_matchSingleton.IsLit) {
						_matchSingleton.DecreaseMatchBrightness ();
				}
		}
}
