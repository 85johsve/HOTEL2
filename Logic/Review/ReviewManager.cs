using Dapper;
using MySqlConnector;
class ReviewManager
{
    private List<Review> reviews;
    ReviewData newReviewData= new();

    public int WriteReview(int customerID, int reservationID, string content)
    {
        int InsertReviewID = newReviewData.InsertReview(customerID, reservationID, content);

        return InsertReviewID;
    }

    public List<Review> ShowAllReviews()
    {
         if (newReviewData.GetReviewList() != null)
        {
            return newReviewData.GetReviewList();
        }
        return null;
       
    }

     public void RemoveReview(int reviewId)    // how to controll this, make sure if the id does not exist and try catch it?
    {
        newReviewData.DeleteReviewById(reviewId);
    }
}