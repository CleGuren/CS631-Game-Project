package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.ResponseMove;
import utility.DataReader;
import core.NetworkManager;

public class RequestMove extends GameRequest {
    private int id;
    private float x, y;
    // Responses
    private ResponseMove responseMove;

    public RequestMove() {
        responses.add(responseMove = new ResponseMove());
    }

    @Override
    public void parse() throws IOException {
        id = DataReader.readInt(dataInput);
        x = DataReader.readFloat(dataInput);
        y = DataReader.readFloat(dataInput);
    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();

        responseMove.setPlayer(player);
        responseMove.setData(id, x, y);
        NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseMove);
    }
}