package core;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import utility.Log;



public class DatabaseManager {
    private static String mySqlUrl = "jdbc:mysql://uj41rc2szbljqbyd:fVclq40jaNTLyyoUfI4Z@b3vrnxrvhmpw2yly49eu-mysql.services.clever-cloud.com:3306/b3vrnxrvhmpw2yly49eu";
    private static String dbUser = "uj41rc2szbljqbyd";
    private static String dbPass = "fVclq40jaNTLyyoUfI4Z";
    private static Connection con = null;

    private DatabaseManager() {
    }

    public static void connect() {
        try {
            con = (Connection)DriverManager.getConnection(mySqlUrl, dbUser, dbPass);
            if (con != null) {
                System.out.println("Database connection successful!");
            }
        }
        catch (SQLException e) {
            Log.println_e(e.getMessage());
        }
    }

    public static void close() {
        try {
            con.close();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public static boolean addUser(String name, String pass) {
        boolean success = false;
        try {
            PreparedStatement stmt = null;
            String query = "INSERT INTO users(username, password)values('" + name + "', '" + pass + "')";
            stmt = con.prepareStatement(query);
            success = (stmt.executeUpdate() != 0);
        } catch (SQLException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        return success;
    }

    public static boolean getUser(String name, String pass) {
        boolean success = false;
        try {
            Statement stmt = con.createStatement();
            String query = "SELECT * FROM users WHERE users.username = '" + name + "' and users.password = '" + pass + "';";
            ResultSet rs = stmt.executeQuery(query);
            success = rs.next();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return success;
    }
}
