using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Tilemaps;
using static CodeUtils;

public class GameIA : MonoBehaviour
{
	static GameObject menuPause, gameGUI, option, victoryOrDefeat;
	static GameObject victory, vitoria, defeat, derrota;
		
	public static int globalMoney = 10000;
	public static GameState gameState = GameState.Normal;

	static GameObject lifeBar = null, killPlacar = null, moneyPlacar = null;
	static bool finishGame = false;
	Text TotalWaves, TimeNextWave;
	
	private static int playerHp, kills, staticMoney;
	private static AudioClip clipLose, clipWin, clipNextWave;
	[SerializeField] int startTime = 12, startMoney, DNAMoney;
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
					victoryOrDefeat.transform.position = new Vector3(0, 0, 0);
					menuPause.transform.position = new Vector3(32, 0, 0);
					gameGUI.transform.position = new Vector3(64, 0, 0);
					option.transform.position = new Vector3(96, 0, 0);
					Time.timeScale = 0;
					finishGame = false;
					if(LanguageBehaviour.language == Language.Portugues)
					{
						derrota.SetActive(true);
					}
					else
					{
						defeat.SetActive(true);
					}
					SoundPlay.PlayClip(clipLose, new Address<float>(in SliderScript.volumeSound), false, false, "Perdemo");
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
	public static int Money
    {
        get
        {
			return staticMoney;
		}
        set
        {
			staticMoney = value;
			moneyPlacar.GetComponent<Text>().text = staticMoney.ToString();
		}
    }
	GameObject miniMenuTorres = null, complementarySystemSquare = null;
	SpriteRenderer renderComplementartSystemSquare = null;
	TowerAbstratc towerRageShow = null;

	[SerializeField] List<Wave> waves;
	[SerializeField] Tilemap mainMap;
	[SerializeField] List<Tilemap> maps;
	[SerializeField] List<Vector2> starts, ends, indentationStarts;
	[SerializeField] List<TileBase> tileGround;
	[SerializeField] List<TileBase> tilePath;
	[SerializeField] List<TileBase> tileTowerPositon;
	List<List<Vector2>> paths = new List<List<Vector2>>();
	List<Grid> pathGrid = new List<Grid>(); 
	static Grid mainGrid;

	IEnumerator corroutineEnemyWave, corroutineTimeWave, corroutineMinTime;
	int waveInd = 0;
	bool minTimeWaveEnd = false;

    void Start()
    {
		clipLose = (AudioClip)Resources.Load("Perdemo");
		clipWin = (AudioClip)Resources.Load("Ganhamo");
		clipNextWave = (AudioClip)Resources.Load("NovaWave");
		
		finishGame = false;
		menuPause = GameObject.Find("MenuPause");
		gameGUI = GameObject.Find("GameGUI");
		option = GameObject.Find("Opções");
		victoryOrDefeat = GameObject.Find("Vitoria/Derrota");
		
		victory = victoryOrDefeat.transform.Find("Victory").gameObject;
		vitoria = victoryOrDefeat.transform.Find("Vitoria").gameObject;
		defeat = victoryOrDefeat.transform.Find("Defeat").gameObject;
		derrota = victoryOrDefeat.transform.Find("Derrota").gameObject;
		victory.SetActive(false);
		vitoria.SetActive(false);
		defeat.SetActive(false);
		derrota.SetActive(false);
		
		playerHp = 100;
		kills = 0;
		lifeBar = GameObject.Find("Front");
		killPlacar = GameObject.Find("KillPlacar");
		moneyPlacar = GameObject.Find("MoneyPlacar");
		complementarySystemSquare = Instantiate((GameObject)Resources.Load("SistemaComplementarAlvo"), transform.position, transform.rotation);
		renderComplementartSystemSquare = complementarySystemSquare.GetComponent<SpriteRenderer>();
		TotalWaves = GameObject.Find("WavesCount").GetComponent<Text>();
		TimeNextWave = GameObject.Find("WavesTime").GetComponent<Text>();
		complementarySystemSquare.SetActive(false);
		PlayerHp = playerHp;
		Kills = kills;
		Money = startMoney;
		gameState = GameState.Normal;
		
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

		StartNextWave(startTime,waveInd);
	}

	void LateUpdate()
    {
		if(Time.timeScale != 0)
        {
			if (Input.GetMouseButtonDown(0))
			{
				ShowChunkData();
			}
		}

		if(FindObjectsOfType<Enemy>().Length == 0 && minTimeWaveEnd && waveInd < waves.Count && !finishGame)
        {
			Money += waves[waveInd - 1].money;
			StartNextWave(6, waveInd);
		}
		else if (FindObjectsOfType<Enemy>().Length == 0 && minTimeWaveEnd && !finishGame)
        {
			lifeBar.transform.localScale = new Vector3(0, 1, 1);
			victoryOrDefeat.transform.position = new Vector3(0, 0, 0);
			menuPause.transform.position = new Vector3(32, 0, 0);
			gameGUI.transform.position = new Vector3(64, 0, 0);
			option.transform.position = new Vector3(96, 0, 0);
			Time.timeScale = 0;
			finishGame = true;
			
			if(LanguageBehaviour.language == Language.Portugues)
			{
				vitoria.SetActive(true);
			}
			else
			{
				victory.SetActive(true);
			}
			SoundPlay.PlayClip(clipWin, new Address<float>(in SliderScript.volumeSound), false, false, "Perdemo");
			
			globalMoney += DNAMoney;
        }

		if(!complementarySystemSquare.activeSelf && ButtonPauseScript.isComplementarySystemActive)
        {
			complementarySystemSquare.SetActive(true);
        }
		else if (ButtonPauseScript.isComplementarySystemActive)
        {
			int x, y;
			mainGrid.GetXY(GetMouseWorldPosition(), out x, out y);
			complementarySystemSquare.transform.position = new Vector3(x * 2 - 15f, y * 2 - 8f, 0);
            if (mainGrid.GetValue(x,y) == GridType.Path)
            {
				renderComplementartSystemSquare.color = new Color(0, 1, 0, 0.5f);
                if (Input.GetMouseButtonDown(0))
                {
					ButtonPauseScript.isComplementarySystemActive = false;
					Money -= 100;
					Instantiate((GameObject)Resources.Load("SistemaComplementar"), complementarySystemSquare.transform.position, complementarySystemSquare.transform.rotation);
				}
				else if (Input.GetMouseButtonDown(1))
				{
					ButtonPauseScript.isComplementarySystemActive = false;
				}
			}
            else
            {
				renderComplementartSystemSquare.color = new Color(1, 0, 0, 0.5f);
				if (Input.GetMouseButtonDown(0))
				{
					ButtonPauseScript.isComplementarySystemActive = false;
				}
				else if (Input.GetMouseButtonDown(1))
				{
					ButtonPauseScript.isComplementarySystemActive = false;
				}
			}
		}
		else if (!ButtonPauseScript.isComplementarySystemActive)
        {
			complementarySystemSquare.SetActive(false);
		}
		
		bool f = Input.GetKeyDown(KeyCode.F);
		if(f && !ButtonPauseScript.isComplementarySystemActive && Money >= 100)
		{
			ButtonPauseScript.isComplementarySystemActive = true;
		}
		else if(f && ButtonPauseScript.isComplementarySystemActive)
		{
			ButtonPauseScript.isComplementarySystemActive = false;
		}
		else if(finishGame || Time.timeScale == 0)
		{
			ButtonPauseScript.isComplementarySystemActive = false;
		}
	}

	void StartNextWave(int time, int ind)
    {
		minTimeWaveEnd = false;
		corroutineTimeWave = TimeToNextWave(time, ind);
		StartCoroutine(corroutineTimeWave);
	}

	IEnumerator TimeToNextWave(int time, int ind)
    {
		TimeNextWave.text = time.ToString();
		TotalWaves.text = $"{waves.Count + (1 + ind - waves.Count)}/{waves.Count}";
		while (time > 0)
        {
			yield return new WaitForSeconds(1);
			time--;
			TimeNextWave.text = time.ToString();
		}
		TimeNextWave.text = time.ToString();
		StartNextWave(ind);
		SoundPlay.PlayClip(clipNextWave, new Address<float>(in SliderScript.volumeSound), false, false, "NextWave");
		StartCountMinTime(waveInd);
		waveInd++;
	}

	void StartCountMinTime(int ind)
    {
		float time = waves[ind].enemyWaves[0].count * waves[ind].enemyWaves[0].time;
		foreach(EnemyWave enemyWave in waves[ind].enemyWaves)
        {
			if (time < enemyWave.count * enemyWave.time) time = enemyWave.count * enemyWave.time;
		}
		corroutineMinTime = CountMinTime(time);
		StartCoroutine(corroutineMinTime);
	}

	IEnumerator CountMinTime(float time)
    {
		yield return new WaitForSeconds(time);
		minTimeWaveEnd = true;
    }

	void StartNextWave(int ind)
    {
		int totalWaves = waves[ind].enemyWaves.Length;
		
		for (int i = 0; i < totalWaves; i++)
		{
			int totalEnemy =  waves[ind].enemyWaves[i].count;
			if(waves[ind].enemyWaves[i].inimigoType.enemyType == EnemyType.Bacterium && UpgradeMenu.antibiotics)
			{
				totalEnemy = (int)(totalEnemy*60f/100f);
			}
			
			if(waves[ind].enemyWaves[i].inimigoType.enemyType == EnemyType.Virus && UpgradeMenu.antiviral)
			{
				totalEnemy = (int)(totalEnemy*60f/100f);
			}
		
			corroutineEnemyWave = CreateEnemyWave(waves[ind].enemyWaves[i].time, totalEnemy, i, ind);
			StartCoroutine(corroutineEnemyWave);
		}
	}

	IEnumerator CreateEnemyWave(float time, int count, int ind, int waveInd)
    {
		while(true)
        {
			yield return new WaitForSeconds(time);
			if (count > 0)
			{
				count--;
				SpawnEnemy(paths[waves[waveInd].paths[ind] - 1], starts[waves[waveInd].paths[ind] - 1], indentationStarts[waves[waveInd].paths[ind] - 1], waves[waveInd].enemyWaves[ind].inimigoType);
			}
			else
			{
				yield break;
			}
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

public enum GameState
{
	Normal,
	Victory,
	Defeat,
}

public enum Upgrades : int
{
	Soap,
	Mask,
	Sanitizer,
}