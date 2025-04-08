create database assetmanagement

create table employees (
    employee_id int primary key identity(1,1),
    name varchar(100) not null,
    department varchar(100) not null,
    email varchar(100) unique not null,
    password varchar(255) not null
)
create table assets (
    asset_id int primary key identity(1,1),
    name varchar(100) not null,
    type varchar(50) not null,
    serial_number varchar(100) unique not null,
    purchase_date date not null,
    location varchar(100) not null,
    status varchar(50) not null check (status in ('in use', 'decommissioned', 'under maintenance')),
    owner_id int,
    foreign key (owner_id) references employees(employee_id) on delete set null
)

create table maintenance_records (
    maintenance_id int primary key identity(1,1),
    asset_id int not null,
    maintenance_date date not null,
    description text not null,
    cost decimal(10,2) not null,
    foreign key (asset_id) references assets(asset_id) on delete cascade
)

create table asset_allocations (
    allocation_id int primary key identity(1,1),
    asset_id int not null,
    employee_id int not null,
    allocation_date date not null,
    return_date date,
    foreign key (asset_id) references assets(asset_id) on delete cascade,
    foreign key (employee_id) references employees(employee_id) on delete cascade
)

create table reservations (
    reservation_id int primary key identity(1,1),
    asset_id int not null,
    employee_id int not null,
    reservation_date date not null,
    start_date date not null,
    end_date date not null,
    status varchar(50) not null check (status in ('pending', 'approved', 'canceled')),
    foreign key (asset_id) references assets(asset_id) on delete cascade,
    foreign key (employee_id) references employees(employee_id) on delete cascade
)

insert into employees (name, department, email, password) 
values 
    ('alice johnson', 'it', 'alice.johnson@example.com', 'password123'),
    ('bob smith', 'finance', 'bob.smith@example.com', 'securepass456')

insert into assets (name, type, serial_number, purchase_date, location, status, owner_id) 
values 
    ('dell laptop', 'electronics', 'sn12345', '2023-01-15', 'headquarters', 'in use', 1),
    ('hp printer', 'electronics', 'pr56789', '2022-05-20', 'branch office', 'under maintenance', 2)


insert into maintenance_records (asset_id, maintenance_date, description, cost) 
values 
    (1, '2024-02-10', 'battery replacement', 50.00),
    (2, '2024-03-05', 'cartridge replacement', 30.00)

insert into asset_allocations (asset_id, employee_id, allocation_date, return_date) 
values 
    (1, 1, '2024-02-01', null),
    (2, 2, '2024-02-15', '2024-03-10')


insert into reservations (asset_id, employee_id, reservation_date, start_date, end_date, status) 
values 
    (1, 2, '2024-04-01', '2024-04-05', '2024-04-10', 'pending'),
    (2, 1, '2024-04-02', '2024-04-07', '2024-04-12', 'approved')

	