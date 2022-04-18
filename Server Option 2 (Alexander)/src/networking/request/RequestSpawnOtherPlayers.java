package networking.request;

// Java Imports
import java.io.IOException;
import java.util.List;
import java.util.stream.Collectors;

// Other Imports
import core.GameServer;
import model.Player;
import core.NetworkManager;
import networking.response.ResponseSpawnPlayer;
import utility.Log;

public class RequestSpawnOtherPlayers extends GameRequest {
    public RequestSpawnOtherPlayers() {}

    @Override
    public void parse() throws IOException {
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();

        // Only Other player and is Spawned in
        GameServer.getInstance().getActivePlayers()
                .stream()
                .filter(p -> p.getID() != player.getID())
                .filter(p -> p.isSpawned())
                .forEach(p -> {
                    Log.println("SpawnOther" + player.getID());
                    ResponseSpawnPlayer responseSpawnPlayer;
                    responses.add(responseSpawnPlayer = new ResponseSpawnPlayer());
                    responseSpawnPlayer.setPlayer(p);
                    responseSpawnPlayer.setPosition(p.getX(), p.getY());
                    NetworkManager.addResponseForUser(player.getID(), responseSpawnPlayer);
                });
    }
}
