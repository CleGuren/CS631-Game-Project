package networking.request;

import java.io.IOException;

import model.Player;
import utility.DataReader;
import networking.response.ResponseLogin;
import networking.response.ResponseName;
import core.NetworkManager;
import core.DatabaseManager;
import core.GameServer;
import utility.Log;

public class RequestLogin extends GameRequest {
    private Player player;
    private String name;
    private String password;

    private ResponseLogin responseLogin;

    public RequestLogin() {
        responses.add(responseLogin = new ResponseLogin());
    }

    @Override
    public void parse() throws IOException {
        // TODO Auto-generated method stub
        name = DataReader.readString(dataInput).trim();
        password = DataReader.readString(dataInput).trim();
    }

    @Override
    public void doBusiness() throws Exception {
        // TODO Auto-generated method stub
        GameServer gs = GameServer.getInstance();
        int id = gs.getID();
        if(id != 0 && DatabaseManager.getUser(name, password)) {
            player = new Player(id, name);
            player.setID(id);
            gs.setActivePlayer(player);

            player.setClient(client);
            // Pass Player reference into thread
            client.setPlayer(player);
            // Set response information
            responseLogin.setData((short) 0, name, id);
            Log.printf("User '%s' has successfully logged in.", player.getName());

            ResponseName responseName = new ResponseName();
            responseName.setPlayer(player);
            NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseName);
        } else {
            Log.printf("A user has tried to join, but failed to do so.");
            responseLogin.setData((short) 1, "", id);
        }
    }
    
}
