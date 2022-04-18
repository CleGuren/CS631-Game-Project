package networking.request;
import java.io.IOException;

import model.Player;
import networking.response.ResponseRegistration;
import utility.DataReader;
import networking.response.ResponseName;
import core.NetworkManager;
import core.DatabaseManager;
import core.GameServer;
import utility.Log;

public class RequestRegistration extends GameRequest {
    private Player player;
    private String name;
    private String password;

    private ResponseRegistration responseRegister;

    public RequestRegistration(){
        responses.add(responseRegister = new ResponseRegistration());
    }
    @Override
    public void parse() throws IOException{
        // TODO Auto-generated method stub
        name = DataReader.readString(dataInput).trim();
        password = DataReader.readString(dataInput).trim();
    }

    @Override
    public void doBusiness() throws Exception{
        // TODO Auto-generated method stub
        GameServer gs = GameServer.getInstance();
        int id = gs.getID();
        if(id != 0 && DatabaseManager.addUser(name, password)) {
            System.out.println("name: " + name);
            player = new Player(id, name);
            player.setID(id);
            gs.setActivePlayer(player);
            player.setClient(client);
            // Pass Player reference into thread
            client.setPlayer(player);
            responseRegister.setData(name, (short) 0);
            Log.printf("User '%s' has successfully registered.", player.getName());

            ResponseName responseName = new ResponseName();
            responseName.setPlayer(player);
            NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseName);
        } else {
            Log.printf("Error. Username exists already.");
            responseRegister.setData("", (short) 1);
        }
    }
}
