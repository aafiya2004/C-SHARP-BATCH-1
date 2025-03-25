--database creation
create database petpals
--Pet table
create table pets (
    petid int primary key identity(1,1),
    name varchar(50) not null,
    age int not null,
    breed varchar(50) not null,
    type varchar(50) not null,
    availableforadoption bit not null
)
--shelter table
create table shelters (
    shelterid int primary key identity(1,1),
    name varchar(255) not null,
    location varchar(255) not null
)
--donations table
create table donations (
    donationid int primary key identity(1,1),
    donorname varchar(255) not null,
    donationtype varchar(50) not null,
    donationamount decimal(10,2),
    donationitem varchar(255),
    donationdate datetime not null
)
--adoptionevents table
create table adoptionevents (
    eventid int primary key identity(1,1),
    eventname varchar(255) not null,
    eventdate datetime not null,
    location varchar(255) not null
)
--participants table
create table participants (
    participantid int primary key identity(1,1),
    participantname varchar(255) not null,
    participanttype varchar(50) not null,
    eventid int,
    foreign key (eventid) references adoptionevents(eventid)
)

--inserting data
insert into pets (name, age, breed, type, availableforadoption) values
('Buddy', 2, 'Labrador', 'Dog', 1),
('Mittens', 3, 'Siamese', 'Cat', 1),
('Rocky', 5, 'Bulldog', 'Dog', 0),
('Whiskers', 1, 'Persian', 'Cat', 1),
('Daisy', 4, 'Golden Retriever', 'Dog', 0)

insert into shelters (name, location) values
('Happy Paws Shelter', 'New York'),
('Safe Haven Shelter', 'Los Angeles'),
('Furry Friends Rescue', 'Chicago')

insert into donations (donorname, donationtype, donationamount, donationitem, donationdate) values
('John Doe', 'Cash', 500.00, null, '2025-03-01'),
('Jane Smith', 'Item', null, 'Dog Food', '2025-02-15'),
('Michael Brown', 'Cash', 250.00, null, '2025-03-10'),
('Emily Davis', 'Item', null, 'Cat Litter', '2025-02-20')

insert into adoptionevents (eventname, eventdate, location) values
('Spring Adoption Fair', '2025-03-15', 'New York'),
('Pet Lovers Meet', '2025-04-10', 'Los Angeles')


insert into participants (participantname, participanttype, eventid) values
('Alice Johnson', 'Volunteer', 1),
('Bob Wilson', 'Pet Owner', 2),
('Charlie Miller', 'Adopter', 1)

select * from pets
select * from shelters
select * from donations
select * from adoptionevents
select * from participants

--5) retrieving list of available pets 
select name,age,breed,type from pets
where availableforadoption=1 or availableforadoption=0

--6) names of participants registered for a specific adoption event
select participantname, participanttype from participants 
where eventid = 1

--8)total donation amount for each shelter
select s.name as shelter_name, sum(d.donationamount) as total_donation 
from shelters s 
left join donations d on s.shelterid = d.donationid 
group by s.name

--9)retrieve pets without owner
select name, age, breed, type
from pets
where availableforadoption = 1

--10) total donation amount for each month and year
select format(donationdate, 'MMMM yyyy') as month_year, sum(donationamount) as total_donation
from donations
where donationamount is not null
group by format(donationdate, 'MMMM yyyy')

--11) distinct breeds for all pets that are either aged between 1 and 3 years or older than 5 years
select distinct breed from pets
where (age between 1 and 3)or(age>5)

--12) pets and their respective shelters where the pets are currently available for adoption
alter table pets 
add shelterid int foreign key references shelters(shelterid)
update pets set shelterid = 1 where name in ('Buddy','Rocky')
update pets set shelterid = 2 where name in ('Mittens','Whiskers')
update pets set shelterid = 3 where name in ('Daisy')
select p.name as pet_name, p.breed, p.type, s.name as shelter_name, s.location
from pets p
join shelters s on p.shelterid = s.shelterid
where p.availableforadoption = 1

--13) the total number of participants in events organized by shelters located in specific city
select count(p.participantid) as total_participants
from participants p
join adoptionevents ae on p.eventid = ae.eventid
join shelters s on ae.location = s.location
where s.location = 'New York'

--14) unique breeds for pets with ages between 1 and 5 years
select distinct breed from pets 
where age between 1 and 5

--15) pets that have not been adopted
select petid, name, age, breed, type 
from pets 
where availableforadoption = 1

--16) the names of all adopted pets along with the adopter's name
create table adoptions (
    adoptionid int primary key identity(1,1),
    petid int not null,
    adopterid int not null,
    adoptiondate datetime not null,
    foreign key (petid) references pets(petid),
    foreign key (adopterid) references participants(participantid)
)

insert into participants (participantname, participanttype, eventid)
values 
    ('John Doe', 'Adopter', null),
    ('Alice Smith', 'Adopter', null),
    ('Michael Johnson', 'Adopter', null)

insert into adoptions (petid, adopterid, adoptiondate)
values 
    (1, 5, '2025-03-01'),  
    (2, 6, '2025-03-05'),  
    (3, 7, '2025-03-10')

select a.adoptionid, p.name as pet_name, pt.participantname as adopter_name, a.adoptiondate
from adoptions a
join pets p on a.petid = p.petid
join participants pt on a.adopterid = pt.participantid


--17)  list of shelters along with the count of pets currently available for adoption
select s.shelterid, s.name as shelter_name, count(p.petid) as available_pets_count
from shelters s
left join pets p on s.shelterid = p.shelterid and p.availableforadoption = 1
group by s.shelterid,s.name

--18) pairs of pets from the same shelter that have the same breed
select p1.petid as pet1_id, p1.name as pet1_name, p2.petid as pet2_id, p2.name as pet2_name, p1.breed, p1.shelterid
from pets p1
join pets p2 on p1.shelterid = p2.shelterid and p1.breed = p2.breed and p1.petid < p2.petid

--19) all possible combinations of shelters and adoption events
select s.shelterid, s.name as shelter_name, ae.eventid, ae.eventname, ae.eventdate, ae.location
from shelters s
cross join adoptionevents ae
order by s.shelterid, ae.eventid

--20) shelter having highest number of pets
select top 1 s.shelterid, s.name as shelter_name, count(a.petid) as adopted_pets
from shelters s
join pets p on s.shelterid = p.shelterid
join adoptions a on p.petid = a.petid
group by s.shelterid, s.name
order by adopted_pets desc

