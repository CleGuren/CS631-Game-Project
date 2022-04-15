package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import core.GameServer;
import core.NetworkManager;
import model.Player;
import networking.response.ResponseJoin;
import networking.response.ResponseName;
import utility.Log;

/**
 * The RequestLogin class authenticates the user information to log in. Other
 * tasks as part of the login process lies here as well.
 */

public class RequestJoin extends GameRequest {
    // Data
    private Player player;

    // Responses
    private ResponseJoin responseJoin;

    public RequestJoin() {
        responses.add(responseJoin = new ResponseJoin());
    }

    @Override
    public void parse() throws IOException {
        //no parsing for this request
    }

    @Override
    public void doBusiness() throws Exception {
        GameServer gs = GameServer.getInstance();
        int id = gs.getID();
        if(id != 0) {
            player = new Player(id, "Player " + id);
            player.setID(id);
            gs.setActivePlayer(player);

            player.setClient(client);
            // Pass Player reference into thread
            client.setPlayer(player);
            // Set response information
            responseJoin.setStatus((short) 0); // Login is a success
            responseJoin.setPlayer(player);
            Log.printf("User '%s' has successfully logged in.", player.getName());

            ResponseName responseName = new ResponseName();
            responseName.setPlayer(player);
            NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseName);
        } else {
            Log.printf("A user has tried to join, but failed to do so.");
            responseJoin.setStatus((short) 1); // Login failed for user
        }
    }
}
