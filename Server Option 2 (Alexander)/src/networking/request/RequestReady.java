package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.ResponseReady;
import core.NetworkManager;

public class RequestReady extends GameRequest {

    // Responses
    private ResponseReady responseReady;

    public RequestReady() {
        responses.add(responseReady = new ResponseReady());
    }

    @Override
    public void parse() throws IOException {
    
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();

        responseReady.setPlayer(player);

        NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseReady);
    }
}