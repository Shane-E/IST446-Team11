using UnityEngine;
using System.Collections;
namespace FMG {
/// <summary>
/// Rotator.
/// </summary>
	public class Rotator : MonoBehaviour {
		/// <summary>
		/// The rotation speed.
		/// </summary>
		public float rotationSpeed = 55;
		public float direction = 1;
		/// <summary>
		/// Up vector
		/// </summary>
		public Vector3 upVec = Vector3.up;
		
		void Update () {
			transform.Rotate( upVec * Time.deltaTime * rotationSpeed * direction) ;

		}
	}
}
