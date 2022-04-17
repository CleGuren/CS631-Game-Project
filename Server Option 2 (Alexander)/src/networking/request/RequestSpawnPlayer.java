package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.ResponseSpawnPlayer;
import utility.DataReader;
import core.NetworkManager;
import utility.Log;

import javax.xml.crypto.Data;

public class RequestSpawnPlayer extends GameRequest {
    // Data
    private float x;
    private float y;

    // Responses
    private ResponseSpawnPlayer responseSpawnPlayer;

    public RequestSpawnPlayer() { responses.add(responseSpawnPlayer = new ResponseSpawnPlayer()); }

    @Override
    public void parse() throws IOException {
        x = DataReader.readFloat(dataInput);
        y = DataReader.readFloat(dataInput);
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();

        player.setPosition(x, y);
        player.setSpawned(true);

        responseSpawnPlayer.setPlayer(player);
        responseSpawnPlayer.setPosition(x, y);

        Log.printf("User \'%s\' set initial Position x: %f, y: %f", player.getID(), x, y);

//        NetworkManager.addResponseForUser(player.getID(), responseSpawnPlayer);
        Log.println("" + player.getID());
        NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseSpawnPlayer);
    }
}
