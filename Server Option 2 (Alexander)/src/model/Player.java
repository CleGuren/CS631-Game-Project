package model;

// Other Imports
import core.GameClient;

/**
 * The Player class holds important information about the player including, most
 * importantly, the account. Such information includes the username, password,
 * email, and the player ID.
 */
public class Player {
    private boolean isReady = false;
    private int player_id;
    private String name;
    private GameClient client; // References GameClient instance

    // Player Position
    private float x;
    private float y;

    private boolean isSpawned;

    public Player(int player_id) {
        this.player_id = player_id;
    }

    public Player(int player_id, String name) {
        this.player_id = player_id;
        this.name = name;
        this.x = 0;
        this.y = 0;
        this.isSpawned = false;
    }

    /**************************
        GETTER and SETTER
    **************************/

    // ID
    public int getID() {
        return player_id;
    }

    public int setID(int player_id) {
        return this.player_id = player_id;
    }

    // Name
    public String getName() {
        return name;
    }

    public String setName(String name) {
        return this.name = name;
    }

    // Client
    public GameClient getClient() {
        return client;
    }

    public GameClient setClient(GameClient client) {
        return this.client = client;
    }

    // Status
    public boolean getReadyStatus() {
        return isReady;
    }

    public void setReadyStatusOn(boolean status) {
        isReady = status;
    }

    // Position
    public float getX() {
        return x;
    }

    public float getY() {
        return y;
    }

    public void setPosition(float x, float y) {
        this.x = x;
        this.y = y;
    }

    // IsSpawned
    public boolean isSpawned() {
        return isSpawned;
    }

    public void setSpawned(boolean isSpawned) {
        this.isSpawned = isSpawned;
    }

    @Override
    public String toString() {
        return "Player{" +
                "player_id=" + player_id +
                ", name='" + name + '\'' +
                '}';
    }
}
