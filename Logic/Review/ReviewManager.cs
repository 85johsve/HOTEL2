using Dapper;
using MySqlConnector;
using System.Data;
public class ReviewManager
{
    //private  List<Review> reviews=new();
    ReviewData newReviewData = new();

    public int WriteReview(int customerID, int reservationID, string content)
    {
        int InsertReviewID = newReviewData.InsertReview(customerID, reservationID, content);

        return InsertReviewID;
    }

    public void RemoveReviewById(int reviewId)    // how to controll this, make sure if the id does not exist and try catch it?
    {
        newReviewData.DeleteReviewById(reviewId);
    }

    public List<Review> ShowAllReviews()
    {
        return newReviewData.GetReviewList();
    }
}