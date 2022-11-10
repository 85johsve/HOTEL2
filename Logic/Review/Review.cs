class Review
{
    public int review_id {get; set;}
    public int reservation_id {get; set;} //Do we need this?
    public int customer_name {get; set;}
    public string review_content {get; set;}

    
    public override string ToString()
    {
        return $"Review: " + review_id + " " + reservation_id + " " + customer_name + " " + review_content;
    }
}