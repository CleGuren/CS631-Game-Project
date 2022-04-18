package networking.response;

import metadata.Constants;
import model.Player;
import utility.GamePacket;
import utility.Log;

public class ResponseLogin extends GameResponse{
    private short status;
    private String name;
    private int player_id;


    public ResponseLogin() {
        responseCode = Constants.SMSG_LOGIN;
    }

    @Override
    public byte[] constructResponseInBytes() {
        // TODO Auto-generated method stub
        GamePacket packet = new GamePacket(responseCode);
        packet.addShort16(status);
        packet.addString(name);
        packet.addInt32(player_id);
        
        return packet.getBytes();
    }

    public void setData(short s, String n, int p) {
        this.status = s;
        this.name = n;
        this.player_id = p;
    }
}
