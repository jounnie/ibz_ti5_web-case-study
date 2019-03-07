create table product
(
  id             int primary key identity,
  name           varchar(255) not null,
  description    varchar(5000),
  visibility     varchar(10)  not null check (visibility in ('ACTIVE', 'HIDDEN')),
  price          decimal(10, 2),
  price_currency varchar(3),
  stock          int,
  order_quantity int
)

create table category
(
  id   int primary key identity,
  name varchar(255) not null
)

create table product_category
(
  id   int primary key identity,
  fk_product  int foreign key references product (id),
  fk_category int foreign key references category (id)
)

create table product_picture
(
  id   int primary key identity,
  fk_product int foreign key references product (id),
  base64     varchar(max) not null
)


create table [user]
(
  id       int primary key identity,
  name     varchar(255)  not null,
  lastname varchar(255)  not null,
  street   varchar(255)  not null,
  zip      varchar(10)   not null,
  country  varchar(50)   not null,
  place    varchar(50)   not null,
  mail     varchar(50)   not null,
  password varchar(1000) not null, -- encrypted, could be longer
  type     varchar(10)   not null check (type in ('USER', 'ADMIN')),
)

create table [order]
(
  id         int primary key identity,
  status     varchar(10)  not null check (status in ('NEW', 'SENT')),
  pay_status varchar(10)  not null check (pay_status in ('UNPAID', 'PAID')),
  date       datetime,
  -- same shipping structure as in the user table (address can change between the orders)
  street     varchar(255) not null,
  zip        varchar(10)  not null,
  country    varchar(50)  not null,
  place      varchar(50)  not null,
  fk_user    int foreign key references [user] (id),
)

create table position
(
  id            int primary key identity,
  fk_order      int foreign key references [order] (id),
  fk_product    int foreign key references product (id),
  quantity      int not null,
  user_currency varchar(3),
  currency_rate decimal(19, 9) -- big enough for all rates (e.g. indonesia rupiah)
)

go

