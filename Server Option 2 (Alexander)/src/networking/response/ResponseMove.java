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
public class ResponseMove extends GameResponse {
    private Player player;
    private int x;
    private int y;
    private int index;

    public ResponseMove() {
        responseCode = Constants.SMSG_MOVE;
    }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addInt32(player.getID());
        packet.addInt32(index);
        packet.addInt32(x);
        packet.addInt32(y);

        Log.printf("Player with id %d has moved piece %d to (%d, %d)", player.getID(), index, x, y);
 
        return packet.getBytes();
    }

    public void setPlayer(Player player) {
        this.player = player;
    }

    public void setData(int index, int x, int y) {
        this.index = index;
        this.y = y; 
        this.x = x;
    }
}