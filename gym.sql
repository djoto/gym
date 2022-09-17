drop database gym;
create database gym;

set sql_safe_updates = 0;

use gym;

create table if not exists GymUser(
	id int auto_increment primary key,
    first_name varchar(30) not null,
    last_name varchar(30) not null,
    e_mail varchar(100) default null,
    user_type varchar(20) not null,
    membership_card varchar(20) not null,
    expire_date varchar(15) not null,
    at_gym_currently varchar(5) not null
);

create table if not exists Staff(
	id int auto_increment primary key,
    first_name varchar(30) not null,
    last_name varchar(30) not null,
    e_mail varchar(100) not null,
    staff_type enum('employee', 'admin') not null,
    pass_hash varchar(100) not null
);

create table if not exists Archive(
	id int auto_increment primary key,
    user_id int not null,
    begin_date varchar(15) not null,
    expire_date varchar(15) not null,
    membership_card varchar(15) not null,
    price varchar(10) not null,
    foreign key(user_id) references GymUser(id) on update restrict on delete restrict
);


create table if not exists Visit(
	id int auto_increment primary key,
	visit_date varchar(15) not null,
    visit_day varchar(15) not null,
    num_visitors int not null
);

create table if not exists Price(
	id int auto_increment primary key,
	user_type varchar(20) not null,
	membership_duration varchar(20) not null,
	price varchar(10) not null
);

insert into GymUser(first_name, last_name, e_mail, user_type, membership_card, expire_date, at_gym_currently) 
	values('Janko', 'Jankovic', 'janko@gmail.com', 'Student', '30 dana', '27.04.2022', 'ne');
insert into GymUser(first_name, last_name, e_mail, user_type, membership_card, expire_date, at_gym_currently) 
	values('Stefan', 'Stefanovic', 'stefan@gmail.com', 'Regularni', '1 dan', '21.04.2022', 'ne');
insert into GymUser(first_name, last_name, e_mail, user_type, membership_card, expire_date, at_gym_currently) 
	values('Rada', 'Radovic', 'rada@gmail.com', 'Student', '30 dana', '15.05.2022', 'ne');
insert into GymUser(first_name, last_name, e_mail, user_type, membership_card, expire_date, at_gym_currently) 
	values('Jovan', 'Jovanovic', 'Nema', 'Student', '1 godina', '12.03.2023', 'ne');
        
insert into Staff(first_name, last_name, e_mail, staff_type, pass_hash) 
	values('Nedeljko', 'Nedeljkovic', 'nedeljko@gmail.com', 'employee', '63079e3f8a47c05d0dba3c50b102273fd4e2f909f893868a1969df095f867dd5');
insert into Staff(first_name, last_name, e_mail, staff_type, pass_hash) 
	values('Ranko', 'Rankovic', 'ranko@gmail.com', 'admin', 'b848d17a7d78b8883e5a973184be62855334711b91991b7d2ddd4ea8ff55ad53');
    
insert into Archive(user_id, begin_date, expire_date, membership_card, price) 
	values(1, '27.03.2022', '27.04.2022', '30 dana', '1800');
insert into Archive(user_id, begin_date, expire_date, membership_card, price) 
	values(2, '20.04.2022', '21.04.2022', '1 dan', '200');
insert into Archive(user_id, begin_date, expire_date, membership_card, price) 
	values(3, '15.04.2022', '15.05.2022', '30 dana', '1800');
insert into Archive(user_id, begin_date, expire_date, membership_card, price) 
	values(4, '12.03.2022', '12.03.2023', '1 godina', '18000');
    

insert into Visit(visit_date, visit_day, num_visitors)
	values('01.03.2022', 'Nedelja', 9);
insert into Visit(visit_date, visit_day, num_visitors)
	values('02.03.2022', 'Ponedeljak', 29);
insert into Visit(visit_date, visit_day, num_visitors)
	values('03.03.2022', 'Utorak', 20);
insert into Visit(visit_date, visit_day, num_visitors)
	values('04.03.2022', 'Sreda', 23);
insert into Visit(visit_date, visit_day, num_visitors)
	values('05.03.2022', 'Četvrtak', 21);
insert into Visit(visit_date, visit_day, num_visitors)
	values('06.03.2022', 'Petak', 30);
insert into Visit(visit_date, visit_day, num_visitors)
	values('07.03.2022', 'Subota', 17);
    
insert into Visit(visit_date, visit_day, num_visitors)
	values('01.04.2022', 'Nedelja', 11);
insert into Visit(visit_date, visit_day, num_visitors)
	values('02.04.2022', 'Ponedeljak', 31);
insert into Visit(visit_date, visit_day, num_visitors)
	values('03.04.2022', 'Utorak', 21);
insert into Visit(visit_date, visit_day, num_visitors)
	values('04.04.2022', 'Sreda', 24);
insert into Visit(visit_date, visit_day, num_visitors)
	values('05.04.2022', 'Četvrtak', 22);
insert into Visit(visit_date, visit_day, num_visitors)
	values('06.04.2022', 'Petak', 28);
insert into Visit(visit_date, visit_day, num_visitors)
	values('07.04.2022', 'Subota', 15);
    
insert into Visit(visit_date, visit_day, num_visitors)
	values('01.05.2022', 'Nedelja', 10);
insert into Visit(visit_date, visit_day, num_visitors)
	values('02.05.2022', 'Ponedeljak', 30);
insert into Visit(visit_date, visit_day, num_visitors)
	values('03.05.2022', 'Utorak', 22);
insert into Visit(visit_date, visit_day, num_visitors)
	values('04.05.2022', 'Sreda', 25);
insert into Visit(visit_date, visit_day, num_visitors)
	values('05.05.2022', 'Četvrtak', 19);
insert into Visit(visit_date, visit_day, num_visitors)
	values('06.05.2022', 'Petak', 32);
insert into Visit(visit_date, visit_day, num_visitors)
	values('07.05.2022', 'Subota', 15);
	
	
insert into Price(user_type, membership_duration, price)
	values('Regularni', '1 dan', '200');
insert into Price(user_type, membership_duration, price)
	values('Regularni', '7 dana', '800');
insert into Price(user_type, membership_duration, price)
	values('Regularni', '30 dana', '2000');
insert into Price(user_type, membership_duration, price)
	values('Regularni', '6 meseci', '10000');
insert into Price(user_type, membership_duration, price)
	values('Regularni', '1 godina', '18000');  

insert into Price(user_type, membership_duration, price)
	values('Student', '1 dan', '150');
insert into Price(user_type, membership_duration, price)
	values('Student', '7 dana', '600');
insert into Price(user_type, membership_duration, price)
	values('Student', '30 dana', '1800');
insert into Price(user_type, membership_duration, price)
	values('Student', '6 meseci', '8000');
insert into Price(user_type, membership_duration, price)
	values('Student', '1 godina', '16000'); 	
    