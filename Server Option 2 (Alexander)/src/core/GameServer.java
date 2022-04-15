package core;

// Java Imports
import java.io.IOException;
import java.net.Socket;
import java.net.ServerSocket;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

//import com.mysql.jdbc.Driver;

// Java Sql Connection
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import core.DatabaseManager;

// Other Imports
import configuration.GameServerConf;
import metadata.Constants;
import metadata.GameRequestTable;
import model.Player;
import utility.ConfFileParser;
import utility.Log;

/**
 * The GameServer class serves as the main module that runs the server.
 * Incoming connection requests are established and redirected to be managed
 * by another class called the GameClient. Several specialized methods are also
 * stored here to perform other specific needs.
 */
public class GameServer {

    // Singleton Instance
    private static GameServer gameServer;
    // Server Variables
    private boolean isDone; // Server Loop Flag
    private GameServerConf configuration; // Stores server config. variables
    private ServerSocket serverSocket;
    private ExecutorService clientThreadPool;
    // Reference Tables
    private Map<String, GameClient> activeThreads = new HashMap<String, GameClient>(); // Session ID -> Client
    private Map<Integer, Player> activePlayers = new HashMap<Integer, Player>(); // Player ID -> Player

    // Sql Information
    String mySqlUrl = "jdbc:mysql://127.0.0.1:3306/?user=root";
    String dbUser = "root";
    String dbPass = "Pickle1!";
    Connection con = null;
    DatabaseManager db;

    private boolean[] occupied = new boolean[2]; 
    /**
     * Create the GameServer by setting up the request types and creating a
     * connection with the database.
     */
    public GameServer() {
        // Load configuration file
        configure();
        // Initialize tables for global use
        GameRequestTable.init(); // Contains request codes and classes
        // Initialize database connection
        // I am commenting out the below DAO as it is game specific.
        /*
        if (DAO.getInstance() == null) {
            Log.println_e("Database Connection Failed!");
            System.exit(-1);
        }*/
        // Preload world-related objects
        initialize();
        // Thread Pool for Clients
        clientThreadPool = Executors.newCachedThreadPool();
    }

    public static GameServer getInstance() {
        if (gameServer == null) {
            gameServer = new GameServer();
        }
        return gameServer;
    }

    /**
     * Load values from a configuration file.
     */
    public final void configure() {
        configuration = new GameServerConf();
        ConfFileParser confFileParser = new ConfFileParser("conf/gameServer.conf");
        configuration.setConfRecords(confFileParser.parse());
    }

    /**
     * Initialize the GameServer by loading a few things into memory.
     */
    public final void initialize() {
        //setupSpeciesTypes();
        //Do what is needed for your game
    }

    /**
     * Retrieve species from the database and load data into memory.
     */

    /**
     * Run the game server by waiting for incoming connection requests.
     * Establishes each connection and stores it into a GameClient to manage
     * incoming and outgoing activity.
     */
    private void run() {
        DatabaseManager.connect();
        try {
            // Connect to db
            // con = (Connection)DriverManager.getConnection(mySqlUrl, dbUser, dbPass);
            // if (con != null) {
            //     System.out.println("Database connection is successful");
            //     // test input
            //     PreparedStatement stmt = null;
            //     String username = "test34";
            //     String userPass = "test1234";
            //     String query = "INSERT INTO gameDB.users(username, password)values('" + username + "', '" + userPass + "')";
            //     stmt = con.prepareStatement(query);
            //     stmt.executeUpdate();
            // }
            // Open a connection using the given port to accept incoming connections
            serverSocket = new ServerSocket(configuration.getPortNumber());
            Log.printf("Server has started on port: %d", serverSocket.getLocalPort());
            Log.println("Waiting for clients...");
            // Loop indefinitely to establish multiple connections
            while (!isDone) {
                try {
                    // Accept the incoming connection from client
                    Socket clientSocket = serverSocket.accept();
                    Log.printf("%s is connecting...", clientSocket.getInetAddress().getHostAddress());
                    // Create a runnable instance to represent a client that holds the client socket
                    String session_id = createUniqueID();
                    GameClient client = new GameClient(session_id, clientSocket);
                    // Keep track of the new client thread
                    addToActiveThreads(client);
                    // Initiate the client
                    clientThreadPool.submit(client);
                } catch (IOException e) {
                    System.out.println(e.getMessage());
                }
            }
        } catch (Exception ex) {
            Log.println_e(ex.getMessage());
        }
        DatabaseManager.close();
    }

    public static String createUniqueID() {
        return UUID.randomUUID().toString();
    }

    public Map<String, GameClient> getActiveThreads() {
        return activeThreads;
    }

    /**
     * Get the GameClient thread for the player using the player ID.
     *
     * @param playerID holds the player ID
     * @return the GameClient thread
     */
    public GameClient getThreadByPlayerID(int playerID) {
        for (GameClient client : activeThreads.values()) {
            Player player = client.getPlayer();

            if (player != null && player.getID() == playerID) {
                return client;
            }
        }

        return null;
    }

    public void addToActiveThreads(GameClient client) {
        activeThreads.put(client.getID(), client);
    }

    public List<Player> getActivePlayers() {
        return new ArrayList<Player>(activePlayers.values());
    }

    public Player getActivePlayer(int player_id) {
        return activePlayers.get(player_id);
    }

    public void setActivePlayer(Player player) {
        activePlayers.put(player.getID(), player);  
    }
    
    public void removeActivePlayer(int player_id) {
        activePlayers.remove(player_id);
        occupied[player_id - 1] = false;
    }

    public int getID() {
        int id = 0;
        int i = 0;
        for(i = 0; i < 2; i++) {
            if(!occupied[i]) {
                id = i + 1; break;
            }
        }
        if(i != 2) {
            occupied[i] = true;
            return id;
        } else
            return 0;
    }

    /**
     * Delete a player's GameClient thread out of the activeThreads
     *
     * @param session_id              The id of the thread.
     */
    public void deletePlayerThreadOutOfActiveThreads(String session_id) {
        activeThreads.remove(session_id);
    }

    /**
     * Initiates the Game Server by configuring and running it. Restarts
     * whenever it crashes.
     *
     * @param args contains additional launching parameters
     */
    public static void main(String[] args) {
        try {
            Log.printf("Homework 4 Server v%s is starting...\n", Constants.CLIENT_VERSION);

            gameServer = new GameServer();
            gameServer.run();
        } catch (Exception ex) {
            Log.println_e("Server Crashed!");
            Log.println_e(ex.getMessage());

            try {
                Thread.sleep(10000);
                Log.println_e("Server is now restarting...");
                GameServer.main(args);
            } catch (InterruptedException ex1) {
                Log.println_e(ex1.getMessage());
            }
        }
    }
}
