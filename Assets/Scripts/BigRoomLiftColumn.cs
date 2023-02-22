using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRoomLiftColumn : MonoBehaviour
{
	/// Used to move the column.
	public Transform columnTransform;

	/// The speed at which the column lowers/raises.
	[Range(0.0f, 1.0f)]
	public float columnSpeed = 0.1f;

	///	AudioSource to play when the column is lowered/raised.
	public AudioSource columnSound;
	///	AudioClip to play when the column is lowered.
	public AudioClip columnLoweredSound;
	///	AudioClip to play when the column is raised.
	public AudioClip columnRaisedSound;

	/// True if the column should be lowered.
	private bool open = false;
	
	/// Update is called once per frame.
	void Update()
	{
		if(open && (columnTransform.position.y > -3.6f))
		{
			columnTransform.position -= Vector3.up * columnSpeed;
		}
		else if(!open && (columnTransform.position.y < 4.0f))
		{
			columnTransform.position += Vector3.up * columnSpeed;
		}
	}

	/// Tells the column to lower.
	public void LowerColumn()
	{
		open = true;

		columnSound.PlayOneShot(columnLoweredSound);
	}

	/// Tells the column to raise.
	public void RaiseColumn()
	{
		open = false;
		
		columnSound.PlayOneShot(columnRaisedSound);
	}
}
