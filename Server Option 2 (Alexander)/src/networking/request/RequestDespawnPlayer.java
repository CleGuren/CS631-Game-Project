package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.ResponseDespawnPlayer;
import utility.DataReader;
import core.NetworkManager;
import utility.Log;

public class RequestDespawnPlayer extends GameRequest {
    private ResponseDespawnPlayer responseDespawnPlayer;

    public RequestDespawnPlayer() { responses.add(responseDespawnPlayer = new ResponseDespawnPlayer()); }

    @Override
    public void parse() throws IOException {
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();

        player.setSpawned(false);

        responseDespawnPlayer.setID(player.getID());
        Log.printf("User %n has been despawned.", player.getID());

        NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseDespawnPlayer);
    }
}
