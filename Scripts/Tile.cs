using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Tile : MonoBehaviour, IPointerClickHandler
{
	private	TextMeshProUGUI	textNumeric;
	private	Board board;
	private	Vector3	correctPosition;

	public int number;

	public bool isMove = true;
	public	bool IsCorrected { private set; get; } = false;

	private	int	numeric;
	public	int	Numeric
	{
		set
		{
			numeric	= value;
			textNumeric.text = numeric.ToString();
		}
		get => numeric;
	}

	
	public void Setup(Board board, int hideNumeric, int numeric)
	{
		this.board	= board;
		textNumeric = GetComponentInChildren<TextMeshProUGUI>();

		Numeric = numeric;
		if ( Numeric == hideNumeric )
		{
			GetComponent<UnityEngine.UI.Image>().enabled = false;
			textNumeric.enabled = false;
		}
	}
	

	public void SetCorrectPosition()
	{
		correctPosition = GetComponent<RectTransform>().localPosition;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		// 클릭했을 때 행동
		board.IsMoveTile(this);
		linkDungeon(this);
		
	}

	public void OnMoveTo(Vector3 end)
	{
		StartCoroutine("MoveTo", end);
	}

	private IEnumerator MoveTo(Vector3 end)
	{
		float	current  = 0;
		float	percent  = 0;
		float	moveTime = 0.1f;
		Vector3	start	 = GetComponent<RectTransform>().localPosition;

		while ( percent < 1 )
		{
			current += Time.deltaTime;
			percent = current / moveTime;

			GetComponent<RectTransform>().localPosition = Vector3.Lerp(start, end, percent);

			yield return null;
		}		
	}
	
	public void linkDungeon(Tile tile)
    {
		for(int i = 0; i < 9; i++)
        {
			if (tile.Numeric == board.dungeons[i].number)
            {
				board.moveDungeon(this);
            }
		}	
    }
}

