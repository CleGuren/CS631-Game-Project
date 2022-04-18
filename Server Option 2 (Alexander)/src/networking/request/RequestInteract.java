package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.ResponseInteract;
import utility.DataReader;
import core.NetworkManager;

public class RequestInteract extends GameRequest {
    private int pieceIndex, targetIndex;
    // Responses
    private ResponseInteract responseInteract;

    public RequestInteract() {
        responses.add(responseInteract = new ResponseInteract());
    }

    @Override
    public void parse() throws IOException {
        pieceIndex = DataReader.readInt(dataInput);
        targetIndex = DataReader.readInt(dataInput);
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();

        responseInteract.setPlayer(player);
        responseInteract.setData(pieceIndex, targetIndex);
        NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseInteract);
    }
}