create table product
(
  id             int primary key identity,
  name           VARCHAR(255) NOT NULL,
  description    VARCHAR(5000),
  visibility     varchar(10)  NOT NULL CHECK (visibility IN ('ACTIVE', 'HIDDEN')),
  price          decimal(10, 2),
  price_currency VARCHAR(3),
  stock          int,
  order_quantity int
)

create table category
(
  id   int primary key identity,
  name VARCHAR(255) NOT NULL
)

create table product_category
(
  fk_product  int foreign KEY references product (id),
  fk_category int foreign KEY references category (id)
)

go

