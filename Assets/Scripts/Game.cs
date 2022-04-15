using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]

public enum Turn {
    Player,
    CPU,
};

public enum Direction {
    Left,
    Right
};

public enum GameState {
    TitleScreen,
    Running,
    Paused,
    GameOver
};

public class Game : MonoBehaviour
{

    public Player player;
    public CPU cpu;
    public Board board;

    public GameObject playerObject;
    public GameObject cpuObject;
    public GameObject boardObject;

    public GameObject GameUI;
    public GameObject PausedUI;

    Turn turn;
    GameState gameState = GameState.TitleScreen;

    private IEnumerator runRoutine;


    void Awake() {
        CardDatabase.init();
    }

    void Start() {
        runRoutine = this.run();
        this.init();
        this.newGame();
    }

    void init() {
        boardObject.SetActive(false);
        playerObject.SetActive(false);
        cpuObject.SetActive(true);
    }

    void newGame() {
        StopCoroutine(runRoutine);
        PausedUI.SetActive(false);
        GameUI.SetActive(true);
        boardObject.SetActive(true);
        playerObject.SetActive(true);
        cpuObject.SetActive(true);
        GameUI.SetActive(true);
        
        player.reset();
        cpu.reset();
        board.reset();
        player.init();
        cpu.init();
        board.init();

        this.turn = Turn.Player;
        gameState = GameState.Running;
        player.beginTurn(board);
        StartCoroutine(runRoutine);
    }

    IEnumerator run() {
        while(gameState == GameState.Running) {
            if(this.turn == Turn.Player) {
                Debug.Log("PlayerTurn loop");
                yield return new WaitForSeconds(2);
            }
            else if (this.turn == Turn.CPU) {
                Debug.Log("CPUTurn loop");
                cpu.beginTurn(board);
                yield return new WaitForSeconds(.5f);
                board.runGameLogic(cpu, player);
                yield return new WaitForSeconds(.5f);
                this.runGameLogic();
                // yield return new WaitForSeconds(.5f);
                player.beginTurn(board);
            }
        }
    }

    void runGameLogic() {
        if(player.health <= 0 || cpu.health <= 0) {
            gameState = GameState.GameOver;
            Debug.Log("--- Game Over ---");
        }
        player.mana = Math.Min(10, player.mana + 3);
        cpu.mana = Math.Min(10, cpu.mana + 3);
        this.updateUI();
        this.changeTurn();
    }

    void updateUI() {
        player.updateUI();
        cpu.updateUI();
    }

    public void exitGameButton() {
        Application.Quit();
    }

    public void newGameButton() {
        this.newGame();
    }

    public void pause() {
        gameState = GameState.Paused;
        this.showPausedUI();
    }

    public void resume() {
        gameState = GameState.Running;
        this.hidePausedUI();
    }

    void showPausedUI() {
        // pause screen. enable
        GameUI.SetActive(false);
        PausedUI.SetActive(true);
    }

    void hidePausedUI() {
        // pause screen. enable
        PausedUI.SetActive(false);
        GameUI.SetActive(true);
    }

    void changeTurn() {
        if(turn == Turn.Player) {
            turn = Turn.CPU;
        }
        else if(turn == Turn.CPU) {
            turn = Turn.Player;
        }
    }

    void Update() {
        if(gameState == GameState.TitleScreen || gameState == GameState.GameOver) {
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.N)){
                this.newGame();
            }
        }
        else if(gameState == GameState.Paused) {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                this.resume();
            }
        }
        else if(gameState == GameState.Running) {
            if(this.turn == Turn.Player){
                if(Input.GetKeyDown(KeyCode.Escape)) {
                    this.pause();
                }
                else if(Input.GetKeyDown(KeyCode.P)) {
                    player.mana += 10;
                    this.updateUI();
                }
                else if(Input.GetKeyDown(KeyCode.O)) {
                    player.health += 10;
                    this.updateUI();
                }
                else if(Input.GetKeyDown(KeyCode.I)) {
                    cpu.health -= 10;
                    this.updateUI();
                }
                else if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backslash)) {
                    player.drawCard();
                }
                else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
                    if(player.hand.displayingHand) {
                        if(player.hand.displayingSelected) {
                            player.moveSelected(Direction.Left, board);
                        }
                        else {
                            player.hoverCard(Direction.Left);
                        }
                    }
                }
                else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
                    if(player.hand.displayingHand) {
                        if(player.hand.displayingSelected) {
                            player.moveSelected(Direction.Right, board);
                        }
                        else {
                            player.hoverCard(Direction.Right);
                        }
                    }
                }
                else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
                    if(player.hand.displayingHand) {
                        if(player.hand.displayingSelected) {
                            player.playCard(board);
                        }
                        else {
                            player.selectCard(board);
                        }
                    }
                }
                else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
                    if(player.hand.displayingHand) {
                        player.deselectCard();
                    }
                }
                else if(Input.GetKeyDown(KeyCode.Q)){
                    player.toggleDisplayHand();
                }
                else if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E)) {
                    player.endTurn();
                    this.changeTurn();
                }
            }
        }
    }
}