package networking.response;

import metadata.Constants;
import model.Player;
import utility.GamePacket;
import utility.Log;

public class ResponseRegistration extends GameResponse {
    private short status;
    private String name;

    public ResponseRegistration(){
        responseCode = Constants.SMSG_REGISTER;
    }

    @Override
    public byte[] constructResponseInBytes(){
        // TODO Auto-generated method stub
        GamePacket packet = new GamePacket(responseCode);
        packet.addShort16(status);
        packet.addString(name);

        return packet.getBytes();
    }

    public void setData(String n, short s){
        this.name = n;
        this.status = s;
    }
}
