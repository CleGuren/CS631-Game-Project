package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.ResponseSpawnPlayer;
import utility.DataReader;
import core.NetworkManager;

public class RequestSpawnPlayer extends GameRequest {
    // Data
    private int x;
    private int y;

    // Responses
    private ResponseSpawnPlayer responseSpawnPlayer;

    public RequestSpawnPlayer() { responses.add(responseSpawnPlayer = new ResponseSpawnPlayer()); }

    @Override
    public void parse() throws IOException {
        x = DataReader.readInt(dataInput);
        y = DataReader.readInt(dataInput);
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();

        player.setPosition(x, y);
        player.setSpawned(true);

        responseSpawnPlayer.setPlayer(player);
        responseSpawnPlayer.setInitialPosition(x, y);

        NetworkManager.addResponseForUser(player.getID(), responseSpawnPlayer);
        NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseSpawnPlayer);
    }
}
