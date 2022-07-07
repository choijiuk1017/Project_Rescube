using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	[SerializeField]
	private GameObject tilePrefab;                              // ���� Ÿ�� ������
	[SerializeField]
	private Transform tilesParent;                          // Ÿ���� ��ġ�Ǵ� "Board" ������Ʈ�� Transform

	
	[SerializeField]
	public DungeonChange dungeonChange;

	Dungeons dungeons;


	public List<Tile> tileList;                                // ������ Ÿ�� ���� ����

	private Vector2Int puzzleSize = new Vector2Int(3, 3);       // 4x4 ����
	private float neighborTileDistance = 102;               // ������ Ÿ�� ������ �Ÿ�. ������ ����� ���� �ִ�.

	public Vector3 EmptyTilePosition { set; get; }          // �� Ÿ���� ��ġ
	public int Playtime { private set; get; } = 0;      // ���� �÷��� �ð�
	public int MoveCount { private set; get; } = 0; // �̵� Ƚ��

	private IEnumerator Start()
	{
		tileList = new List<Tile>();
		
		SpawnTiles();

		UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(tilesParent.GetComponent<RectTransform>());

		// ���� �������� ����� ������ ���
		yield return new WaitForEndOfFrame();
		EmptyTilePosition = tileList[tileList.Count - 1].GetComponent<RectTransform>().localPosition;
		// tileList�� �ִ� ��� ����� SetCorrectPosition() �޼ҵ� ȣ��
		tileList.ForEach(x => x.SetCorrectPosition());

		//StartCoroutine("OnSuffle");
		// ���ӽ��۰� ���ÿ� �÷��̽ð� �� ���� ����
		//StartCoroutine("CalculatePlaytime");
	}

    private void Update()
    {
		linkDungeon(dungeonChange);
    }

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

		// ���� ���� ����� �ٸ� ����̾��µ� UI, GridLayoutGroup�� ����ϴٺ��� �ڽ��� ��ġ�� �ٲٴ� ������ ����
		// �׷��� ���� Ÿ�ϸ���Ʈ�� �������� �ִ� ��Ұ� ������ �� Ÿ��
		EmptyTilePosition = tileList[tileList.Count - 1].GetComponent<RectTransform>().localPosition;
	}

	public void IsMoveTile(Tile tile)
	{
		if (Vector3.Distance(EmptyTilePosition, tile.GetComponent<RectTransform>().localPosition) == neighborTileDistance)
		{
			Vector3 goalPosition = EmptyTilePosition;

			EmptyTilePosition = tile.GetComponent<RectTransform>().localPosition;

			tile.OnMoveTo(goalPosition);

			// Ÿ���� �̵��� ������ �̵� Ƚ�� ����
			MoveCount++;
		}
	}

	public void linkDungeon(DungeonChange dungeonChange)
    {
		for(int i = 0; i < 9; i++)
        {
			dungeonChange.dungeons[i].transform.position = tileList[i].transform.position;
        }
    }

	private IEnumerator CalculatePlaytime()
	{
		while (true)
		{
			Playtime++;

			yield return new WaitForSeconds(1);
		}
	}
}
