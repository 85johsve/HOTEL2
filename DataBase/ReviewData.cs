using Dapper;
using MySqlConnector;
class ReviewData : Database
{
    Database reviewdb = new Database();
    MySqlConnection connection;


    public ReviewData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));

    }
    public List<Review> GetReviews()
    {
        var reviews = connection.Query<Review>("SELECT review_id,reservation_id, review_content FROM reviews INNER JOIN customers ON reviews.customer_id=customers.customer_id;").ToList();
        return reviews;

    }
}

//"SELECT room_id,roomType_name,roomStatus_name,room_price FROM ((rooms INNER JOIN roomtype ON rooms.roomType_id=roomtype.roomType_id) INNER JOIN roomstatus ON rooms.roomStatus_id=roomstatus.roomStatus_id) ;").ToList();

    // public int review_id {get; set;}
    // public int reservation_id {get; set;} //Do we need this?
    // public int customer_fname {get; set;}
    // public string review_contant {get; set;}