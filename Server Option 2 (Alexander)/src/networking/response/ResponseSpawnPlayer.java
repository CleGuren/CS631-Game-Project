package networking.response;

// Other Imports
import metadata.Constants;
import model.Player;
import utility.GamePacket;

public class ResponseSpawnPlayer extends GameResponse {
    private Player player;
    private int x;
    private int y;

    public ResponseSpawnPlayer() { responseCode = Constants.SMSG_SPAWN_PLAYER; }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addInt32(player.getID());
        packet.addString(player.getName());
        packet.addInt32(x);
        packet.addInt32(y);

        return packet.getBytes();
    }

    public void setPlayer(Player player) { this.player = player; }

    public void setInitialPosition(int x, int y) {
        this.x = x;
        this.y = y;
    }
}
