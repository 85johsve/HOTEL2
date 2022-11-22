using Dapper;
using MySqlConnector;
using System.Data;
public class ReviewManager
{
    ReviewData newReviewData = new();

    public List<Review> ShowAllReviews()
    {
        return newReviewData.GetReviewList();
    }

    public int WriteReview(int customerID, int reservationID, string content)
    {
        int InsertReviewID = newReviewData.InsertReview(customerID, reservationID, content);

        return InsertReviewID;
    }

    public void RemoveReviewById(int reviewId) 
    {
        newReviewData.DeleteReviewById(reviewId);
    }


}