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
ConsoleApp

Logik:
Booking
Checkin
User(Base class)
Customer(:User)
Staff(:User)
Database
Enum
Idatabase
Product(Base class)
OtherProducts(:Product)
Room(:Product)
Review
Transaction



NOTES:
TimeSpan
DateOnly