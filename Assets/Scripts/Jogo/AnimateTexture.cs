using UnityEngine;
using System.Collections;

public class AnimateTexture : MonoBehaviour 
{
	public int ColumnCount = 1;
	public int RowCount = 1;

	public int RowIndex	= 0; 
	public int ColumnIndex = 0; 
	public int TotalCellsOfRow = 8;
	public int Fps = 8;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SpriteAnimation();
	}
	
	private void SpriteAnimation()
	{
		int index = CalculateIndex();
		Vector2 size = CalculateSize();
		Vector2 offset = CalculateOffset(index, size);

		SetOffset(offset);
		SetSize(size);
	}
	
	private int CalculateIndex()
	{
		return ((int)(Time.time * Fps)) % TotalCellsOfRow;
	}
	
	private Vector2 CalculateSize()
	{
		return new Vector2(1.0f / ColumnCount, 1.0f / RowCount);
	}
	
	private Vector2 CalculateOffset(int index, Vector2 size)
	{
		float horizontalIndex = index % ColumnCount;	
		float verticalIndex = index / ColumnCount;
		
		return new Vector2((float)((horizontalIndex + ColumnIndex) * size.x), (float)((1.0 - size.y) - (verticalIndex + RowIndex) * size.y));
	}
	
	private void SetOffset(Vector2 offset)
	{
		renderer.material.SetTextureOffset("_MainTex", offset);
	}
	
	private void SetSize(Vector2 size)
	{
		renderer.material.SetTextureScale("_MainTex", size);
	}
}
