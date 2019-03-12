create table product
(
  id             int primary key identity,
  name           varchar(255)   not null,
  description    varchar(5000)  not null,
  visibility     varchar(10)    not null check (visibility in ('ACTIVE', 'HIDDEN')),
  price          decimal(10, 2) not null,
  price_currency varchar(3)     not null,
  stock          int            not null,
  order_quantity int
)

create table category
(
  id              int primary key identity,
  name            varchar(255) not null,
  parent_category int foreign key references category (id)
)

create table product_category
(
  id          int primary key identity,
  fk_product  int not null foreign key references product (id),
  fk_category int not null foreign key references category (id)
)

create table product_picture
(
  id         int primary key identity,
  fk_product int          not null foreign key references product (id),
  base64     varchar(max) not null
)


create table [user]
(
  id       int primary key identity,
  forename varchar(255)  not null,
  lastname varchar(255)  not null,
  street   varchar(255)  not null,
  zip      varchar(10)   not null,
  country  varchar(50)   not null,
  place    varchar(50)   not null,
  email    varchar(50)   not null,
  password varchar(1000) not null, -- encrypted, could be longer
  type     varchar(10)   not null check (type in ('USER', 'ADMIN')),
)

create table [order]
(
  id            int primary key identity,
  status        varchar(10)  not null check (status in ('NEW', 'SENT')),
  pay_status    varchar(10)  not null check (pay_status in ('UNPAID', 'PAID')),
  date          datetime     not null,
  -- same shipping structure as in the user table (address can change between the orders)
  street        varchar(255) not null,
  zip           varchar(10)  not null,
  country       varchar(50)  not null,
  place         varchar(50)  not null,
  fk_user       int          not null foreign key references [user] (id),
  user_currency varchar(3),
  currency_rate decimal(19, 9), -- big enough for all rates (e.g. indonesia rupiah)
  total         decimal(19, 9)
)

create table position
(
  id         int primary key identity,
  fk_order   int not null foreign key references [order] (id),
  fk_product int not null foreign key references product (id),
  quantity   int not null,
)

go

