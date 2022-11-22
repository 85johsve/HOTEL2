public class Receipt
{
    public DateTime print_date { get; set; }
    public int receipt_nr { get; set; }
    protected static int fake_ID = 11111;

    public Receipt(DateTime printDate)
    {
        this.print_date = printDate;
        this.receipt_nr = fake_ID++;
    }

    public override string ToString()
    {
        return $@"Date: " + print_date + "\nReceipt Nr: " + fake_ID;
    }
}