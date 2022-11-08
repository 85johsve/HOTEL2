# HOTEL
Functions:

[ ]Show available rooms (customer/staff) >Booking
    -should be able to look at availability at specific date

[ ]Book room (customer/staff) >Booking
    -choose room from list(single, double, sweet)
    -chose check in date
    -choose check out date
    -optional choices(breakfast, extra bed...)

[ ]Write reviews (customer) >Review
    -add text
    -add score 1-5
    -we could also add "ask a question"

[ ]Read reviews (customer/staff)

[ ]Add room (staff) >Room

[ ]Remove romm (staff)

[ ]Check in (staff) >Checkin
    -mark room as unavailable
    -needs creditcard information?

[ ]Check out (staff)
    -calculate price for room(roomprice * days)
    -add price for optional choices
    -set room as available
    -write reciept



Classes:

UI:
Program
Menu

LOGIK:

Reservations
[] Booking
[] CheckingIN
[] CheckOut

Customer
[]Register Customer
[] LogIn

Staff
[]LogIn


Database/IDatabase
[]Connections, and get all data

Enum :
[]Meny Enum
[]Room Type Enum
[]Job Title Enum
[]Room Status Enum
[]Review score Enum

//OtherProduct? Seperat Class Put on later?


Room
[] Constructor

RoomManager
[]Add Room
[]Remove Room
[]ShowAvailable Room
[]Book Room


Review
[]Write Reviews
[]Read Reviews
[]tar bort

Transaction
[]Print Receipt
[]Payment




DataBase Quaries:
[x] List of Rooms

 "SELECT customer_id,customer_fname,customer_lname,customer_phone,customer_email,customer_city,customer_country,counstomer_address FROM customers;"

[] List of employee Tina
[] List of Customer Jessica
[] Join tables  get List of Transaction (Tina)
[] Join tables get List of Reservations (johan)
[] List of Reviews                        SELECT * FROM `reviews`;


NOTES:
TimeSpan
DateOnly