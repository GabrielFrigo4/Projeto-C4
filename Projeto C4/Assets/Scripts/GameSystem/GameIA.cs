using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Tilemaps;
using static CodeUtils;

public class GameIA : MonoBehaviour, ILanguage
{
	static GameObject lifeBar = null, killPlacar = null;
	private static int playerHp, kills;
	[SerializeField] int money;
	public static int PlayerHp
	{
		get
		{
			return playerHp;
		}
		set
		{
			playerHp = value;
			if(lifeBar != null)
			{
				if(playerHp > 0)
				{
					lifeBar.transform.localScale = new Vector3(playerHp/100f, 1f, 1f);
				}
				else
				{
					lifeBar.transform.localScale = new Vector3(0, 1, 1);
				}
			}
		}
	}
	public static int Kills
    {
        get
        {
			return kills;
		}
        set
        {
			kills = value;
			killPlacar.GetComponent<Text>().text = kills.ToString();
		}
    }
	GameObject miniMenuTorres = null; 
	TowerAbstratc towerRageShow = null;

	[SerializeField] Tilemap mainMap;
	[SerializeField] List<Tilemap> maps;
	[SerializeField] List<Vector2> starts, ends, indentationStarts;
	[SerializeField] List<TileBase> tileGround;
	[SerializeField] List<TileBase> tilePath;
	[SerializeField] List<TileBase> tileTowerPositon;
	List<List<Vector2>> paths = new List<List<Vector2>>();
	List<Grid> pathGrid = new List<Grid>(); 
	static Grid mainGrid;

	const float maxTime = 1, maxTime2 = 5;
	float time = maxTime, time2 = maxTime2;
	
    void Start()
    {
		playerHp = 100;
		kills = 0;
		lifeBar = GameObject.Find("Front");
		killPlacar = GameObject.Find("KillPlacar");
		PlayerHp = playerHp;
		Kills = kills;
		
        mainGrid = new Grid(16, 8, 2f, transform.position);
		UpdateGridToTilemapValue(mainGrid, mainMap);
		for(int i = 0; i < maps.Count; i++)
		{
			pathGrid.Add(new Grid(16, 8, 2f, transform.position));
			paths.Add(new List<Vector2>());
		}
		
		for(int i = 0; i < maps.Count; i++)
		{
			UpdateGridToTilemapValue(mainGrid, maps[i]);
			UpdateGridToTilemapValue(pathGrid[i], maps[i]);
			GetPath(paths[i], starts[i], pathGrid[i]);
		}
		
		(this as ILanguage).SetLanguage();
		if(!LanguageBehaviour.languageBehaviour.Contains(this))
		{
			LanguageBehaviour.languageBehaviour.Add(this);
		}
		
		foreach(Vector2 pos in starts)
		{
			Vector2 _pos = new Vector3(pos.x*2 - 15f, pos.y*2 - 8f, 0);
			Instantiate((GameObject)Resources.Load("start"), _pos, transform.rotation);
		}
		
		foreach(Vector2 pos in ends)
		{
			Vector2 _pos = new Vector3(pos.x*2 - 15f, pos.y*2 - 8f, 0);
			Instantiate((GameObject)Resources.Load("end"), _pos, transform.rotation);
		}
    }

    void LateUpdate()
    {
		time -= Time.deltaTime;
		if(time <= 0)
        {
			for(int i = 0; i < maps.Count; i++)
			{
                switch (i)
                {
					case 1:
						SpawnEnemy(paths[i], starts[i], indentationStarts[i], (InimigoType)Resources.Load("Virus2"));
						break;
					default:
						SpawnEnemy(paths[i], starts[i], indentationStarts[i], (InimigoType)Resources.Load("Virus1"));
						break;
                }
			}
			time += maxTime;
		}

		time2 -= Time.deltaTime;
		if (time2 <= 0)
		{
			for (int i = 0; i < maps.Count; i++)
			{
				switch (i)
				{
					case 0:
						SpawnEnemy(paths[i], starts[i], indentationStarts[i], (InimigoType)Resources.Load("Gírus1"));
						break;
					default:
						SpawnEnemy(paths[i], starts[i], indentationStarts[i], (InimigoType)Resources.Load("Virus1"));
						break;
				};
			}
			time2 += maxTime2;
		}

		if(Time.timeScale != 0)
        {
			if (Input.GetMouseButtonDown(0))
			{
				ShowChunkData();
			}
		}
	}
	
	void ILanguage.SetLanguage()
	{
		switch(LanguageBehaviour.language)
		{
			case Language.Portugues:
				killPlacar.GetComponent<Text>().text = $"Abates: {kills}";
				break;
			case Language.English:
				killPlacar.GetComponent<Text>().text = $"Kill: {kills}";
				break;
		}
	}
	
	void GetPath(List<Vector2> path, Vector2 start, Grid grid)
	{	
		void GetNextPosition(Vector2 position, Vector2 direction)
		{
			path.Add(position);
			Vector2 up, down, left, right;
			up = position + Vector2.up;
			down = position + Vector2.down;
			left = position + Vector2.left;
			right = position + Vector2.right;
			
			if(grid.GetValue((int)up.x, (int)up.y) == GridType.Path && !path.Contains(up))
			{
				GetNextPosition(up, Vector2.up);
			}
			else if(grid.GetValue((int)down.x, (int)down.y) == GridType.Path && !path.Contains(down))
			{
				GetNextPosition(down, Vector2.down);
			}
			else if(grid.GetValue((int)left.x, (int)left.y) == GridType.Path && !path.Contains(left))
			{
				GetNextPosition(left, Vector2.left);
			}
			else if(grid.GetValue((int)right.x, (int)right.y) == GridType.Path && !path.Contains(right))
			{
				GetNextPosition(right, Vector2.right);
			}
            else
            {
				path.Add(position + direction);
			}
		}
		
		GetNextPosition(start, Vector2.zero);
	}

	void SpawnEnemy(List<Vector2> path, Vector2 start, Vector2 indentationStart, InimigoType type)
    {
		Vector3 createPosition = start * 2 + new Vector2(-15f, -8f) + indentationStart * 2;
		GameObject inimigo = Instantiate((GameObject)Resources.Load("Enemy"), createPosition, Quaternion.identity);
		Enemy en = inimigo.GetComponent<Enemy>();
		en.inimigoType = type;

		List<Vector2> arrayVar = new List<Vector2>();

		path.ForEach((item) =>
		{
			arrayVar.Add(item);
		});

		en.path = arrayVar;
	}

	void UpdateGridToTilemapValue(Grid grid, Tilemap map)
	{
		for (int x = 0; x < 18; x++)
		{
			for (int y = 0; y < 8; y++)
			{
				TileBase b = map.GetTile(new Vector3Int(x, y, 0));

				if (tileGround.Contains(b))
				{
					grid.SetValue(x, y, GridType.Ground);
				}
				else if (tilePath.Contains(b))
				{
					grid.SetValue(x, y, GridType.Path);
				}
				else if (tileTowerPositon.Contains(b))
				{
					grid.SetValue(x, y, GridType.TowerPosition);
				}
			}
		}
	}

	void ShowChunkData()
    {
		Vector3 spawnPosition = GetMouseWorldPosition();
		Vector2Int gridPosition;

		if (ValidatePosition(ref spawnPosition, out gridPosition))
		{
			GridData data = mainGrid.GetValue(gridPosition.x, gridPosition.y);
			if (data.tower == null)
            {
				if (towerRageShow != null) towerRageShow.ShowRange = false;
				SpawnTowerOptions(spawnPosition, gridPosition);
			}
            else
            {
				if (towerRageShow != null) towerRageShow.ShowRange = false;
				towerRageShow = data.tower;
				towerRageShow.ShowRange = true;
				Destroy(miniMenuTorres);
			}
		}
        else
        {
			Destroy(miniMenuTorres);
			if (towerRageShow != null)
			{
				towerRageShow.ShowRange = false;
				towerRageShow = null;
			}
		}
	}

	void SpawnTowerOptions(Vector3 spawnPosition, Vector2Int gridPosition)
    {
		if (miniMenuTorres != null) Destroy(miniMenuTorres);
		miniMenuTorres = Instantiate((GameObject)Resources.Load("MiniMenuTorres"), spawnPosition, Quaternion.identity);
		MenuTorresBehaviour menuTorres = miniMenuTorres.GetComponent<MenuTorresBehaviour>();
		menuTorres.gridPosition = gridPosition;
	}

	public static void SpawnTower(string data, Vector3 spawnPosition, Vector2Int gridPosition)
	{
		GameObject obj = Instantiate((GameObject)Resources.Load("Tower"), spawnPosition, Quaternion.identity);
		obj.GetComponent<TowerGenerator>().CreateTowerType((TowerType)Resources.Load(data));
		TowerAbstratc tower = obj.GetComponent<TowerAbstratc>();
		mainGrid.SetValue(gridPosition.x, gridPosition.y, tower);
	}

	bool ValidatePosition(ref Vector3 position, out Vector2Int gridPosition)
	{
		int x, y;
		mainGrid.GetXY(position, out x, out y);
		
		if(mainGrid.GetValue(x, y) == GridType.TowerPosition)
		{
			position = new Vector3(x*2 - 15f, y*2 - 8f, 0);
			gridPosition = new Vector2Int(x, y);
			return true;
		}
		else
		{
			gridPosition = new Vector2Int(x, y);
			return false;
		}
	}
}