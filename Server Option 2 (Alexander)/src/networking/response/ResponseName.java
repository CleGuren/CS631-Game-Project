package networking.response;

// Other Imports
import metadata.Constants;
import model.Player;
import utility.GamePacket;
import utility.Log;
/**
 * The ResponseLogin class contains information about the authentication
 * process.
 */
public class ResponseName extends GameResponse {
    private Player player;

    public ResponseName() {
        responseCode = Constants.SMSG_SETNAME;
    }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addInt32(player.getID());
        packet.addString(player.getName());

        Log.printf("Name %s set in server. for player with id %d", player.getName(), player.getID());

        return packet.getBytes();
    }

    public void setPlayer(Player player) {
        this.player = player;
    }
}