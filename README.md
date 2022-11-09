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
[x] List of Rooms(Tina)

"SELECT room_id,roomType_name,roomStatus_name,room_price FROM ((rooms INNER JOIN roomtype ON rooms.roomType_id=roomtype.roomType_id) INNER JOIN roomstatus ON rooms.rommStatus_id=roomstatus.roomStatus_id) ;"

[] List of employee (Tina)

[x] List of Customer Jessica

 "SELECT customer_id,customer_fname,customer_lname,customer_phone,customer_email,customer_city,customer_country,counstomer_address FROM customers;"

[] Join tables  get List of Transaction (Tina)

[x] Join tables get List of Reservations (johan)

SELECT reservations.reservation_id, reservations.date_in, reservations.date_out, employees.employee_fname, reservations.room_id, customers.customer_fname, customers.customer_lname
FROM reservations
INNER JOIN customers ON reservations.customer_id = customers.customer_id
INNER JOIN employees ON reservations.employee_id = employees.employee_id;


[x] List of Reviews                       

 SELECT * FROM `reviews`;

Admin class? We call RoomManager class and Login here.
Maybe we should have a Product base class, so we can add other products besides room int the futrue. 

NOTES:
TimeSpan
DateOnly