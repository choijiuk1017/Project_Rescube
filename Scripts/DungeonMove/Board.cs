using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	[SerializeField]
	private GameObject tilePrefab; // 숫자 타일 프리팹
	[SerializeField]
	private Transform tilesParent; // 타일이 배치되는 "Board" 오브젝트의 Transform

	[SerializeField]
	public Dungeons[] dungeons; // 던전


	public List<Tile> tileList; // 생성한 타일 정보 저장

	private Vector2Int puzzleSize = new Vector2Int(3, 3);  // 3x3 퍼즐
	private float neighborTileDistance = 102; // 인접한 타일 사이의 거리. 별도로 계산할 수도 있다.

	public Vector3 EmptyTilePosition { set; get; } // 빈 타일의 위치


	public GameObject emptyDungeon; // 빈 던전
	public GameObject emptyTile;// 빈 타일
	public GameObject player;

	private IEnumerator Start()
	{
		tileList = new List<Tile>();
		
		SpawnTiles();

		UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(tilesParent.GetComponent<RectTransform>());

		// 현재 프레임이 종료될 때까지 대기
		yield return new WaitForEndOfFrame();

		EmptyTilePosition = tileList[puzzleSize.x*puzzleSize.y -1].GetComponent<RectTransform>().localPosition;

		//tileList에 있는 모든 요소의 SetCorrectPosition() 메소드 호출
		tileList.ForEach(x => x.SetCorrectPosition());

		//StartCoroutine("OnSuffle");
		// 게임시작과 동시에 플레이시간 초 단위 연산
		//StartCoroutine("CalculatePlaytime");
	}

    private void Update()
    {
		
	}
	
	// 타일 스폰 함수
    private void SpawnTiles()
	{
		for (int y = 0; y < puzzleSize.y; ++y)
		{
			for (int x = 0; x < puzzleSize.x; ++x)
			{
				GameObject clone = Instantiate(tilePrefab, tilesParent);
				Tile tile = clone.GetComponent<Tile>();

				tile.Setup(this, puzzleSize.x * puzzleSize.y, y * puzzleSize.x + x + 1);

				tileList.Add(tile);
			}
		}
	}
	

	/*
	private IEnumerator OnSuffle()
	{
		float current = 0;
		float percent = 0;
		float time = 1.5f;

		while (percent < 1)
		{
			current += Time.deltaTime;
			percent = current / time;

			int index = Random.Range(0, puzzleSize.x * puzzleSize.y);
			tileList[index].transform.SetAsLastSibling();

			yield return null;
		}

		// 원래 셔플 방식은 다른 방식이었는데 UI, GridLayoutGroup을 사용하다보니 자식의 위치를 바꾸는 것으로 설정
		// 그래서 현재 타일리스트의 마지막에 있는 요소가 무조건 빈 타일
		EmptyTilePosition = tileList[tileList.Count - 1].GetComponent<RectTransform>().localPosition;
	}
	*/

	// 타일 이동 함수
	public void IsMoveTile(Tile tile)
	{
		if (Vector3.Distance(EmptyTilePosition, tile.GetComponent<RectTransform>().localPosition) == neighborTileDistance)
		{
			Vector3 goalPosition = EmptyTilePosition;

			if (Vector3.Distance(player.transform.position, dungeons[tile.Numeric - 1].transform.position) < 15.5f)
			{
				return;
			}

			EmptyTilePosition = tile.GetComponent<RectTransform>().localPosition;

			tile.OnMoveTo(goalPosition);
		}
	}


	// 던전 이동 함수
	public void moveDungeon(Tile tile)
    {
		Vector3 goalPosition = emptyDungeon.transform.position;
		if(Vector3.Distance(dungeons[tile.Numeric-1].transform.position, goalPosition) <= 24)
        {
			if (Vector3.Distance(player.transform.position, dungeons[tile.Numeric - 1].transform.position) < 15.5f)
			{
				return;
			}
			emptyDungeon.transform.position = Vector3.Lerp(emptyDungeon.transform.position, dungeons[tile.Numeric - 1].transform.position, 1);
			dungeons[tile.Numeric - 1].OnMoveTo(goalPosition);
		}
		
	}


}
