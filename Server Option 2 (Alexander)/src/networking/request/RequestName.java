package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.ResponseName;
import utility.DataReader;
import core.NetworkManager;

public class RequestName extends GameRequest {
    // Data
    private String name;

    // Responses
    private ResponseName responseName;

    public RequestName() {
        responses.add(responseName = new ResponseName());
    }

    @Override
    public void parse() throws IOException {
        name = DataReader.readString(dataInput).trim();
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();
       
        player.setName(name);
        responseName.setPlayer(player);

        NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseName);
    }
}