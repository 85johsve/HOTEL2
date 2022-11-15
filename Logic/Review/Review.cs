class Review
{
    public int review_id {get; set;}
    public int reservation_id {get; set;} //Do we need this?
    public int customer_id {get; set;}
    public string? review_content {get; set;}
     public string? customer_fname {get; set;}

    
    public override string ToString()
    {
        return $"Review: " + review_id + "\nReservation:" + reservation_id + "\nCustomer Account " + customer_id + "\nCustomer Name " + customer_fname + "\n" + review_content;
    }
}