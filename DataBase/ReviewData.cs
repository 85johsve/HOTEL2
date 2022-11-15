using Dapper;
using MySqlConnector;
using System.Data;
class ReviewData 
{
    
    MySqlConnection connection;


    public ReviewData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));

    }
      public void Open()
    {
        if(connection.State != ConnectionState.Open)
            connection.Open();
    }

    public List<Review> GetReviews()
    {
        Open();
        var reviews = connection.Query<Review>("SELECT review_id, reservation_id, customer_fname, review_content FROM reviews INNER JOIN customers ON customers.customer_id=reviews.customer_id;").ToList();
        return reviews;

    }

     public int InsertReview(int customerID, int reservationID, string content)
    {
         Open();//int id, 
        var r = new DynamicParameters();
        r.Add("@customer_id", customerID);
        r.Add("@reservation_id", reservationID);
        r.Add("@review_content", content);
        string sql = $@"INSERT INTO reviews (customer_id, reservation_id, review_content) VALUES (@customer_id,@reservation_id,@review_content); SELECT LAST_INSERT_ID() ";
        int Id = connection.Query<int>(sql, r).First();

        return Id;
    }

    public void DeleteReview(int number)
    {
        Open();
        var deleteReview = connection.QuerySingle<Review>($"DELETE FROM reviews WHERE review_id = {number};");

    }
}

//"SELECT room_id,roomType_name,roomStatus_name,room_price FROM ((rooms INNER JOIN roomtype ON rooms.roomType_id=roomtype.roomType_id) INNER JOIN roomstatus ON rooms.roomStatus_id=roomstatus.roomStatus_id) ;").ToList();

    // public int review_id {get; set;}
    // public int reservation_id {get; set;} //Do we need this?
    // public int customer_fname {get; set;}
    // public string review_contant {get; set;}