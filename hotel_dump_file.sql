drop table if exists booking;
drop table if exists guest;
drop table if exists rooms;
drop table if exists hotels;
drop table if exists hotel_chains;

create table hotel_chains(
id int,
name varchar(45),
primary key (id)
);

create table hotels(
id int,
hotel_chains_id int, 
name varchar(45),
address varchar(45),
city varchar(45),
distance_to_center double,
star_rating int,
primary key (id),
foreign key (hotel_chains_id) references hotel_chains(id) 
);

create table rooms(
id int,
hotel_id int,
room_type varchar(45),
price double,
capacity int,
primary key (id),
foreign key (hotel_id) references hotels(id)
);

create table guest(
id int,
name varchar(45),
passport_number varchar(70),
primary key(id)
);

create table booking(
id int,
room_id int,
guest_who_booked_id int,
start_date varchar(45),
end_date varchar(45),
num_of_guests int,
num_of_rooms int,
time_arrival varchar(45),
primary key(id),
foreign key (room_id) references rooms(id),
foreign key (guest_who_booked_id) references guest(id)
);

insert into hotel_chains () values(1, "Radisson Hotel Group");

insert into hotels () values (1, 1, "Radisson Lyngby", "Lyngbyvej 4", "Copenhagen", 43.12, 2);
insert into hotels () values (2, 1, "Radisson Køge", "Køgevej 20", "Copenhagen", 12.32, 4);
insert into hotels () values (3, 1, "Radisson Glostrup", "Glostrupvej 3", "Copenhagen", 1.12, 1);

insert into rooms()values(1, 1, "large", 700, 5);
insert into rooms()values(2, 1, "small", 700, 2);
insert into rooms()values(3, 1, "medium", 700, 3);
insert into rooms()values(4, 1, "huge", 700, 7);
insert into rooms()values(5, 1, "tiny", 700, 1);

insert into guest()values(1, "test_user", "95234");



