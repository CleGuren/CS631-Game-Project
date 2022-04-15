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

    public Player(int player_id) {
        this.player_id = player_id;
    }

    public Player(int player_id, String name) {
        this.player_id = player_id;
        this.name = name;
    }

    public int getID() {
        return player_id;
    }

    public int setID(int player_id) {
        return this.player_id = player_id;
    }

    public String getName() {
        return name;
    }

    public String setName(String name) {
        return this.name = name;
    }

    public GameClient getClient() {
        return client;
    }

    public boolean getReadyStatus() {
        return isReady;
    }

    public void setReadyStatusOn(boolean status) {
        isReady = status;
    }
    

    public GameClient setClient(GameClient client) {
        return this.client = client;
    }

    @Override
    public String toString() {
        return "Player{" +
                "player_id=" + player_id +
                ", name='" + name + '\'' +
                '}';
    }
}
