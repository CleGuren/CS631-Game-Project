package networking.response;

// Other Imports
import metadata.Constants;
import model.Player;
import utility.GamePacket;

public class ResponseDespawnPlayer extends GameResponse {
    private int user_id;

    public ResponseDespawnPlayer() {responseCode = Constants.SMSG_DESPAWN_PLAYER; }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addInt32(user_id);

        return packet.getBytes();
    }

    public void setID(int user_id) { this.user_id = user_id; }
}
