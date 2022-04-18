package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.ResponseLeave;
import core.NetworkManager;

public class RequestLeave extends GameRequest {
    // Responses
    private ResponseLeave responseLeave;

    public RequestLeave() {
        responses.add(responseLeave = new ResponseLeave());
    }

    @Override
    public void parse() throws IOException {
    
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();

        responseLeave.setPlayer(player);

        NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseLeave);
    }
}