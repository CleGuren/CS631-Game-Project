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
public class ResponseInteract extends GameResponse {
    private Player player;
    private int targetIndex;
    private int index;

    public ResponseInteract() {
        responseCode = Constants.SMSG_INTERACT;
    }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addInt32(player.getID());
        packet.addInt32(index);
        packet.addInt32(targetIndex);


        Log.printf("Player with id %d has had a piece at index %d interact with another player's piece at index %d.", player.getID(), index, targetIndex);
 
        return packet.getBytes();
    }

    public void setPlayer(Player player) {
        this.player = player;
    }

    public void setData(int index, int targetIndex) {
        this.index = index;
        this.targetIndex = targetIndex;
    }
}